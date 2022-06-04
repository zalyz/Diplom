using Ambulance.CallApi.Client;
using Ambulance.Domain.Models.Call;
using Ambulance.Domain.Models.Enums;
using Ambulance.ServiceAPI.Client;
using System;
using System.Windows;
using System.Windows.Threading;

namespace Ambulance.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Domain.Models.Dispatcher _dispatcher { get; set; }

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
            DispatcherTimer LiveTime = new()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            LiveTime.Start();

            ComboStreets.ItemsSource = _serviceClient.ServiceResource.GetStreets().GetAwaiter().GetResult(); ;
            ComboReason.ItemsSource = _serviceClient.ServiceResource.GetDiagnosis().GetAwaiter().GetResult();
            ComboCaller.ItemsSource = _serviceClient.ServiceResource.GetCallers().GetAwaiter().GetResult();
        }

        public void DispetcherClick(object sender, RoutedEventArgs e)
        {
            DispatcherRegistrationWindow dispatcherRegistrationWindow = new(_serviceClient)
            {
                Owner = this
            };
            dispatcherRegistrationWindow.ShowDialog();
            _dispatcher = dispatcherRegistrationWindow.Dispatcher;
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
            if (_dispatcher != null)
            {
                var callMonitoring = new CallMonitoring(_dispatcher, _callClient);
                callMonitoring.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не зарегистрировались как диспетчер");
            }
        }

        // Обработка вызова
        private void EditCallWindow_Click(object sender, RoutedEventArgs e)
        {
            if (_dispatcher != null)
            {
                var editCallsWindow = new EditingCalls(_dispatcher, _callClient, _serviceClient);
                editCallsWindow.Owner = this;
                editCallsWindow.Show();
            }
            else
            {
                MessageBox.Show("Вы не зарегистрировались как диспетчер");
            }
        }

        private void DataWindow_Click(object sender, RoutedEventArgs e)
        {
            if (_dispatcher != null)
            {
                var dataWindow = new DataWindow(_callClient, _serviceClient);
                dataWindow.Show();
            }
            else
            {
                MessageBox.Show("Вы не зарегистрировались как диспетчер");
            }
        }

        private void SearchForCallInformation_Click(object sender, RoutedEventArgs e)
        {
            if (_dispatcher != null)
            {
                var searchCallInformation = new SearchInformationAboutCall(_callClient);
                searchCallInformation.Show();
            }
            else
            {
                MessageBox.Show("Вы не зарегистрировались как диспетчер");
            }
        }

        private async void AcceptCall_Click(object sender, RoutedEventArgs e)
        {
            if (_dispatcher != null)
            {
                try
                {
                    var streetId = (int)ComboStreets.SelectedValue;
                    var houseNumber = textHouseNumber.Text;
                    var flatNumber = textFlatNumber.Text;
                    var FIO = textFIO.Text;
                    var age = int.Parse(textAge.Text);
                    var reasonId = (int)ComboReason.SelectedValue;
                    var callerId = (int)ComboCaller.SelectedValue;
                    var callType = string.Equals(ComboUrgency.Text, "Неотложный") ? 0 : 1;
                    var phoneNumber = textTelephoneNumber.Text;
                    var callNotes = textBoxNote.Text + "\n" + phoneNumber;

                    var call = new CreateCallRequest
                    {
                        FIO = FIO,
                        StreetId = streetId,
                        HouseNumber = houseNumber,
                        FlatNumber = flatNumber,
                        Age = age,
                        CallerId = callerId,
                        PhoneNumber = phoneNumber,
                        DispatcherId = _dispatcher.Id,
                        DiagnosisId = reasonId,
                        DateTimeReception = DateTime.Now,
                        CallNotes = callNotes,
                        CallType = (CallType)callType,
                    };

                    var number = await _callClient.CallOperations.CreateCall(call);

                    MessageBox.Show($"Вызов добавлен с номером: {number}");
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

        private void AddStreet_Click(object sender, RoutedEventArgs e)
        {
            if (_dispatcher != null)
            {
                var addStreet = new AddStreet(_serviceClient)
                {
                    Owner = this,
                };
                addStreet.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не зарегистрировались как диспетчер");
            }
        }

        private void AddDiagnosis_Click(object sender, RoutedEventArgs e)
        {
            if (_dispatcher != null)
            {
                var addStreet = new AddDiagnosis(_serviceClient)
                {
                    Owner = this,
                };
                addStreet.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не зарегистрировались как диспетчер");
            }
        }
    }
}
