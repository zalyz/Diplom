using Ambulance.CallApi.Client;
using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Call;
using Ambulance.Domain.Models.Enums;
using Ambulance.ServiceAPI.Client;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Ambulance.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<AmbulanceBrigade> Brigade = new ObservableCollection<AmbulanceBrigade>();

        //public static ObservableCollection<ProcessedCall> AmbulanceCallsForProcessing = new ObservableCollection<ProcessedCall>();

        private static readonly ObservableCollection<CallOfficeInfo> ambulanceCalls = new ObservableCollection<CallOfficeInfo>();

        private string _dispatcher { get; set; }

        private readonly ICallApiClient _callClient;

        private readonly IServiceApiClient _serviceClient;

        public MainWindow(ICallApiClient callClient, IServiceApiClient serviceClient)
        {
            _callClient = callClient;
            _serviceClient = serviceClient;
            InitializeWindow();
        }

        public void InitializeWindow()
        {
            InitializeComponent();
            DispatcherTimer LiveTime = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            LiveTime.Start();

            ComboStreets.ItemsSource = _serviceClient.ServiceResource.GetStreets().GetAwaiter().GetResult();
            ComboReason.ItemsSource = _serviceClient.ServiceResource.GetDiagnosis().GetAwaiter().GetResult();
            ComboCaller.ItemsSource = _serviceClient.ServiceResource.GetCallers().GetAwaiter().GetResult();
        }

        public void DispetcherClick(object sender, RoutedEventArgs e)
        {
            //DispatcherRegistrationWindow dispatcherRegistrationWindow = new DispatcherRegistrationWindow
            //{
            //    Owner = this
            //};
            //dispatcherRegistrationWindow.ShowDialog();
            //_dispatcher = dispatcherRegistrationWindow.AmbDispatcher;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboStreets.Text = "";
            textHouseNumber.Clear();
            textFlatNumber.Clear();
            textTelephoneNumber.Clear();
            textFIO.Clear();
            textAge.Clear();
            ComboReason.Text = "";
            ComboCaller.Text = "";
            ComboUrgency.Text = "";
            textBoxNote.Clear();
        }

        private void CallMonitoring_Click(object sender, RoutedEventArgs e)
        {
            //if (_dispatcher != null)
            //{
            //    var callMonitoring = new CallMonitoring(ambulanceCalls, _dispatcher);
            //    callMonitoring.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Вы не зарегистрировались как диспетчер");
            //}
        }

        private void EditCallWindow_Click(object sender, RoutedEventArgs e)
        {
            //if (_dispatcher != null)
            //{
            //    var editCallsWindow = new EditingCalls(_dispatcher);
            //    editCallsWindow.Owner = this;
            //    editCallsWindow.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Вы не зарегистрировались как диспетчер");
            //}
        }

        private void DataWindow_Click(object sender, RoutedEventArgs e)
        {
            //if (_dispatcher != null)
            //{
            //    var dataWindow = new DataWindow(Brigade);
            //    dataWindow.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Вы не зарегистрировались как диспетчер");
            //}
        }

        private void SearchForCallInformation_Click(object sender, RoutedEventArgs e)
        {
            //if (_dispatcher != null)
            //{
            //    var searchCallInformation = new SearchInformationAboutCall();
            //    searchCallInformation.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Вы не зарегистрировались как диспетчер");
            //}
        }

        private async Task AcceptCall_Click(object sender, RoutedEventArgs e)
        {
            if (_dispatcher != null)
            {
                try
                {
                    var street = ComboStreets.Text;
                    var houseNumber = textHouseNumber.Text;
                    var flatNumber = textFlatNumber.Text;
                    var FIO = textFIO.Text;
                    var age = int.Parse(textAge.Text);
                    var reason = ComboReason.Text;
                    var whoCalled = ComboCaller.Text;
                    var callType = ComboUrgency.Text;
                    var phoneNumber = textTelephoneNumber.Text;
                    var callNotes = textBoxNote.Text + "\n" + phoneNumber;

                    var call = new CreateCallRequest
                    {
                        FIO = FIO,
                        Street = street,
                        HouseNumber = houseNumber,
                        FlatNumber = flatNumber,
                        Age = age,
                        CallerId = 123,
                        PhoneNumber = phoneNumber,
                        DispatcherId = 123,
                        DateTimeReception = DateTime.Now,
                        CallNotes = callNotes,
                        CallType = Enum.Parse<CallType>(callType),
                    };

                    await _callClient.CallOperations.CreateCall(call);

                    MessageBox.Show("OK");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Вы не зарегистрировались как диспетчер");
            }
        }

        private void AddWorker_Click(object sender, RoutedEventArgs e)
        {
            //var workerWindow = new WorkerWindow
            //{
            //    Owner = this
            //};
            //workerWindow.ShowDialog();
        }

        private void AddDiagnosis_Click(object sender, RoutedEventArgs e)
        {
            //var addDiagnosisWindow = new AddDiagnosis(true)
            //{
            //    Owner = this
            //};
            //addDiagnosisWindow.ShowDialog();
        }

        private void AddStreet_Click(object sender, RoutedEventArgs e)
        {
            //var addDiagnosisWindow = new AddDiagnosis(false)
            //{
            //    Owner = this
            //};
            //addDiagnosisWindow.ShowDialog();
        }

        private void EmergencyEnter_Click(object sender, RoutedEventArgs e)
        {
            //if (_dispatcher != null)
            //{
            //    var inputCallWindow = new InputCall(WindowTypes.EnterCall, _dispatcher)
            //    {
            //        Owner = this
            //    };
            //    inputCallWindow.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Вы не зарегистрировались как диспетчер");
            //}
        }

        private void EditCallMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //if (_dispatcher != null)
            //{
            //    var reprocessingCallsWindow = new ReprocessingCallsWindow
            //    {
            //        Owner = this
            //    };
            //    reprocessingCallsWindow.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Вы не зарегистрировались как диспетчер");
            //}
        }

        private void ReportMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //var reportWindow = new ReportWindow()
            //{
            //    Owner = this
            //};
            //reportWindow.Show();
        }

        private void ChronicButton_Click(object sender, RoutedEventArgs e)
        {
            //if (_dispatcher != null)
            //{
            //    var chronicPatientWindow = new ChronicPatientWindow();
            //    chronicPatientWindow.Owner = this;
            //    chronicPatientWindow.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Вы не зарегистрировались как диспетчер");
            //}
        }

        public static void AddAmbulanceCall(CallOfficeInfo ambulanceCall)
        {
            ambulanceCalls.Add(ambulanceCall);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (_dispatcher != null)
            {
                if (MessageBox.Show("Действительно выйти?", "Диспетчер", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _dispatcher = null;
                    Title = "Скорая помощь";
                }
            }
            else
            {
                MessageBox.Show("Диспетчер не введен!");
            }
        }
    }
}
