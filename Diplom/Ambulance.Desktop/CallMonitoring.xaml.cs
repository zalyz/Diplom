using System;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Collections.ObjectModel;
using Ambulance.Domain.Models;
using Ambulance.CallApi.Client;
using Ambulance.Domain.Models.Brigade;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for CallMonitoring.xaml
    /// </summary>
    public partial class CallMonitoring : Window
    {
        private ObservableCollection<CallOfficeInfo> _calls { get; } = new ObservableCollection<CallOfficeInfo>();

        private ObservableCollection<BrigadeMonitoringInfo> _brigade = new();

        private ObservableCollection<int> _listOfBrigadeNumbers { get; set; } = new ObservableCollection<int>();

        private Dispatcher _dispatcher;

        private readonly ICallApiClient _callApiClient;

        public CallMonitoring(Dispatcher dispatcher, ICallApiClient callApiClient)
        {
            _callApiClient = callApiClient;
            InitializeComponent();
            var calls = callApiClient.CallOperations.GetAccepted().GetAwaiter().GetResult();
            calls.ForEach(e => _calls.Add(e));
            var brigades = callApiClient.BrigadeOperations.GetBrigadesMonitoringInfo().GetAwaiter().GetResult();
            brigades.ForEach(e => _brigade.Add(e));

            _dispatcher = dispatcher;
            callDataGrid.ItemsSource = _calls;
            carsDataGrid.ItemsSource = _brigade;
            FillListOfBrigadeNumbers();
            comboBrigadeNumbers.ItemsSource = _listOfBrigadeNumbers;
        }

        private void FillListOfBrigadeNumbers()
        {
            foreach (var item in _brigade)
            {
                _listOfBrigadeNumbers.Add(item.Number);
            }
        }

        private void callData_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (callDataGrid.SelectedItem != null)
            {
                var call = _calls[callDataGrid.SelectedIndex];
                textCallMonitoringNumber.Text = call.CallNumber.ToString();
                textCallMonitoringFIO.Text = call.FIO;
                textCallMonitoringStreet.Text = call.Street;
                textCallMonitoringHouse.Text = call.HouseNumber;
                textCallMonitoringFlat.Text = call.FlatNumber.ToString();
                textCallMonitoringAge.Text = call.Age.ToString();
                textCallMonitoringReason.Text = call.Diagnosis;
                textCallMonitoringWho.Text = call.Caller;
                textCallMonitoringReceptionTime.Text = call.DateTimeReception.ToString("hh:mm");
                textCallMonitoringTransmissionTime.Text = call.TransferDateTime.ToString("hh:mm");
                textCallMonitoringInformation.Text = call.CallNotes;
            }
        }

        public async void CarRow_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var indexOfselectedCar = carsDataGrid.SelectedIndex;
                var brigade = _brigade[indexOfselectedCar];
                if (brigade.CallId != 0)
                {
                    var call = await _callApiClient.CallOperations.GetCall(brigade.CallId);
                    var callInformation = new CallInformation(call)
                    {
                        Owner = this
                    };
                    callInformation.Show();
                }
            }
            catch
            {
                MessageBox.Show("");
            }
        }

        private async void TransferToBrigade_Click(object sender, RoutedEventArgs e)
        {
            if (callDataGrid.SelectedIndex >= 0)
            {
                try
                {
                    var brigadeNumber = int.Parse(comboBrigadeNumbers.Text);
                    var brigade = _brigade.First(e => e.Number == brigadeNumber);
                    if (brigade.CallId == 0)
                    {
                        var call = _calls[callDataGrid.SelectedIndex];
                        var now = DateTime.Now;
                        await _callApiClient.BrigadeOperations.AssignCallToBrigade(new AssignCallRequest
                        {
                            BrigadeId = brigade.Id,
                            CallId = call.Id,
                            TransferDateTime = now,
                            TransferingDispatcherId = _dispatcher.Id,
                        });
                        call.TransferDateTime = now;
                        call.TransferingDispatcherId = _dispatcher.Id;
                        brigade.CallId = call.Id;
                        brigade.Street = call.Street;
                        brigade.HouseNumber = call.HouseNumber;
                        brigade.CallNumber = call.CallNumber;
                        brigade.ActionDateTime = call.TransferDateTime;
                        _calls.Remove(call);

                        UpdateCarsGrid();
                    }
                    else
                    {
                        MessageBox.Show("Бригаде уже передан вызов.", "Ошибка передачи вызова");
                    }
                }
                catch
                {
                    MessageBox.Show("Не верный номер бригады");
                }
            }
        }

        private async void ReturnCall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var brigade = _brigade[carsDataGrid.SelectedIndex];
                if (brigade.CallId != 0)
                {
                    await _callApiClient.BrigadeOperations.ReturnCall(brigade.Id);
                    var call = await _callApiClient.CallOperations.GetCall(brigade.CallId);
                    brigade.CallId = 0;
                    brigade.Street = string.Empty;
                    brigade.HouseNumber = string.Empty;
                    brigade.CallNumber = null;
                    brigade.ActionDateTime = DateTime.Now;
                    _calls.Add(call);
                    UpdateCarsGrid();
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void UpdateCarsGrid()
        {
            carsDataGrid.ItemsSource = null;
            carsDataGrid.ItemsSource = _brigade;
        }

        private async void FreeAtStation_Click(object sender, RoutedEventArgs e)
        {
            var carIndex = carsDataGrid.SelectedIndex;
            if (carIndex >= 0)
            {
                var brigade = _brigade[carIndex];
                if (brigade.CallId != 0)
                {
                    await _callApiClient.BrigadeOperations.ReleaseBrigade(brigade.Id);
                    brigade.CallId = 0;
                    brigade.Street = string.Empty;
                    brigade.HouseNumber = string.Empty;
                    brigade.CallNumber = null;
                    brigade.ActionDateTime = DateTime.Now;
                    UpdateCarsGrid();
                }
            }
        }

        private async void CarsDataGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var carIndex = carsDataGrid.SelectedIndex;
            if (carIndex >= 0)
            {
                var brigade = _brigade[carIndex];
                var calls = await _callApiClient.BrigadeOperations.GetCalls(brigade.Id);
                var carInformationWindow = new CarsInfrmationWindow(_callApiClient, brigade.Id);
                carInformationWindow.Owner = this;
                carInformationWindow.ShowDialog();
            }
        }
    }
}
