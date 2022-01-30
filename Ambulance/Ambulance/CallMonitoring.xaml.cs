using System;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Collections.ObjectModel;
using Ambulance.Classes;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for CallMonitoring.xaml
    /// </summary>
    public partial class CallMonitoring : Window
    {
        private ObservableCollection<AmbulanceCall> _calls { get; }

        private ObservableCollection<uint> _listOfBrigadeNumbers { get; set; } = new ObservableCollection<uint>();

        private string _dispatcher;

        public CallMonitoring(ObservableCollection<AmbulanceCall> ambulanceCalls, string dispatcher)
        {
            InitializeComponent();
            _calls = ambulanceCalls;
            _dispatcher = dispatcher;
            callDataGrid.ItemsSource = _calls;
            carsDataGrid.ItemsSource = MainWindow.Brigade;
            FillListOfBrigadeNumbers();
            comboBrigadeNumbers.ItemsSource = _listOfBrigadeNumbers;
            comboDirection.ItemsSource = ServerService.GetDirections();
        }

        private void FillListOfBrigadeNumbers()
        {
            foreach (var item in MainWindow.Brigade)
            {
                _listOfBrigadeNumbers.Add(item.Number);
            }
        }

        private void callData_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.callDataGrid.SelectedItem != null)
            {
                textCallMonitoringNumber.Text = _calls[this.callDataGrid.SelectedIndex].CallNumber.ToString();
                textCallMonitoringFIO.Text = _calls[this.callDataGrid.SelectedIndex].Patient.FIO;
                textCallMonitoringStreet.Text = _calls[this.callDataGrid.SelectedIndex].Patient.Street;
                textCallMonitoringHouse.Text = _calls[this.callDataGrid.SelectedIndex].Patient.HouseNumber.ToString();
                textCallMonitoringFlat.Text = _calls[this.callDataGrid.SelectedIndex].Patient.FlatNumber.ToString();
                textCallMonitoringAge.Text = _calls[this.callDataGrid.SelectedIndex].Patient.Age.ToString();
                textCallMonitoringReason.Text = _calls[this.callDataGrid.SelectedIndex].Diagnosis;
                textCallMonitoringWho.Text = _calls[this.callDataGrid.SelectedIndex].WhoCalled;
                textCallMonitoringReceptionTime.Text = _calls[this.callDataGrid.SelectedIndex].DateTimeReception.ToString("hh:mm");
                textCallMonitoringTransmissionTime.Text = _calls[this.callDataGrid.SelectedIndex].TransferDateTime.ToString("hh:mm");
                textCallMonitoringInformation.Text = _calls[this.callDataGrid.SelectedIndex].CallNotes;
            }
        }

        public void CarRow_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var indexOfselectedCar = carsDataGrid.SelectedIndex;
                var brigade = MainWindow.Brigade[indexOfselectedCar];
                if (brigade.IsOnCall)
                {
                    var call = brigade.AmbulanceCalls.Last();
                    var callInformation = new CallInformation(call);
                    callInformation.Owner = this;
                    callInformation.Show();
                }
            }
            catch
            {
                MessageBox.Show("");
            }
        }

        private void TransferToBrigade_Click(object sender, RoutedEventArgs e)
        {
            if (callDataGrid.SelectedIndex >= 0)
            {
                try
                {
                    var brigadeNumber = int.Parse(comboBrigadeNumbers.Text);
                    var brigade = MainWindow.Brigade.First(e => e.Number == brigadeNumber);
                    if (!brigade.IsOnCall)
                    {
                        var call = _calls[this.callDataGrid.SelectedIndex];
                        call.TransferDateTime = DateTime.Now;
                        call.TransferringDispatcher = _dispatcher.ToString();
                        brigade.SendCall(call);
                        brigade.IsOnCall = true;
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

        private void ReturnCall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var brigade = MainWindow.Brigade[carsDataGrid.SelectedIndex];
                if (brigade.IsOnCall)
                {
                    var returnedCall = brigade.AmbulanceCalls.LastOrDefault();
                    if (returnedCall != null)
                    {
                        _calls.Add(returnedCall);

                        brigade.AmbulanceCalls.Remove(returnedCall);
                        brigade.IsOnCall = false;
                        brigade.AtTheStation();
                        UpdateCarsGrid();
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void UpdateCarsGrid()
        {
            carsDataGrid.ItemsSource = null;
            carsDataGrid.ItemsSource = MainWindow.Brigade;
        }

        private void FreeAtStation_Click(object sender, RoutedEventArgs e)
        {
            var carIndex = carsDataGrid.SelectedIndex;
            if (carIndex >= 0)
            {
                var brigade = MainWindow.Brigade[carIndex];
                if (brigade.IsOnCall)
                {
                    brigade.AtTheStation();
                    brigade.IsOnCall = false;
                    brigade.AmbulanceCalls.Last().Department = brigade.StationName;
                    var ambulanceCalls = brigade.AmbulanceCalls.Last();
                    var processedCall = new ProcessedCall
                    {
                        CallNumber = ambulanceCalls.CallNumber, PatientId = ambulanceCalls.Patient.Id,
                        Patient = ambulanceCalls.Patient, AmbulanceBrigade = brigade, DateTimeReception = ambulanceCalls.DateTimeReception,
                        TransferDateTime = ambulanceCalls.TransferDateTime, CallType = ambulanceCalls.Type, TransferringDispatcher = ambulanceCalls.TransferringDispatcher,
                        CallNotes = ambulanceCalls.CallNotes
                    };
                    MainWindow.AmbulanceCallsForProcessing.Add(processedCall);
                    UpdateCarsGrid();
                }
            }
        }

        private void DirectionButton_Click(object sender, RoutedEventArgs e)
        {
            var carIndex = carsDataGrid.SelectedIndex;
            if (carIndex >= 0)
            {
                var direction = comboDirection.Text;
                if (!string.IsNullOrEmpty(direction))
                {
                    MainWindow.Brigade[carIndex].StreetOfLastCall = direction;
                    MainWindow.Brigade[carIndex].ActionTime = DateTime.Now.ToString("hh:mm");
                    MainWindow.Brigade[carIndex].IsOnCall = true;
                    UpdateCarsGrid();
                }
            }
        }

        private void FreeButton_Click(object sender, RoutedEventArgs e)
        {
            if (carsDataGrid.SelectedIndex >= 0)
            {
                var brigade = MainWindow.Brigade[carsDataGrid.SelectedIndex];
                if (brigade.IsOnCall)
                {
                    brigade.AtTheStation();
                    brigade.IsOnCall = false;
                    UpdateCarsGrid();
                }
            }
        }

        private void CarsDataGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var carIndex = carsDataGrid.SelectedIndex;
            if (carIndex >= 0)
            {
                var carInformationWindow = new CarsInfrmationWindow(MainWindow.Brigade[carIndex]);
                carInformationWindow.Owner = this;
                carInformationWindow.ShowDialog();
            }
        }
    }
}
