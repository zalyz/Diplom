using System;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Text.RegularExpressions;
using Ambulance.CallApi.Client;
using Ambulance.ServiceAPI.Client;
using Ambulance.Domain.Models.Brigade;
using Ambulance.Domain.Models.Enums;
using System.Collections.ObjectModel;
using Ambulance.Domain.Models;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        private readonly ICallApiClient _callApiClient;
        private readonly IServiceApiClient _serviceApiClient;

        private ObservableCollection<AmbulanceBrigade> _brigades = new();

        public DataWindow(ICallApiClient callApiClient, IServiceApiClient serviceApiClient)
        {
            _callApiClient = callApiClient;
            _serviceApiClient = serviceApiClient;
            InitializeComponent();
            dateAutoBrigade.SelectedDate = DateTime.Now;
            SetupData();
        }

        private async void SetupData()
        {
            var brigades = await _callApiClient.BrigadeOperations.GetBrigades();
            brigades.ForEach(e => _brigades.Add(e));
            comboDoktor.ItemsSource = await _serviceApiClient.EmployeeResource.GetDoktorsAsync();
            var assistants = await _serviceApiClient.EmployeeResource.GetMedicalAssistants();
            comboMedcalAssistant1.ItemsSource = assistants;
            comboMedcalAssistant2.ItemsSource = assistants;
            comboOrderly.ItemsSource = await _serviceApiClient.EmployeeResource.GetOrderlies();
            comboDriver.ItemsSource = await _serviceApiClient.EmployeeResource.GetDrivers();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void AddBrigade_Click(object sender, RoutedEventArgs e)
        {
            var brigadeNumber = int.Parse(textBrigadeNumber.Text);
            var brigadeType = string.Equals(comboBrigadeType.Text, "Неотложная") ? BrigadeType.Emergency : BrigadeType.Resuscitation;
            var doktorId = (int)comboDoktor.SelectedValue;
            var firstMedAssistId = (int)comboMedcalAssistant1.SelectedValue;
            int? secondMedAssistId = (int?)comboMedcalAssistant2.SelectedValue;
            var orderlyId = (int)comboOrderly.SelectedValue;
            var driverId = (int)comboDriver.SelectedValue;
            var department = comboDepartment.Text;

            await _callApiClient.BrigadeOperations.CreateBrigade(new CreateBrigadeRequest
            {
                Number = brigadeNumber,
                DoktorId = doktorId,
                FirstMedicalAssistantId = firstMedAssistId,
                SecondMedicalAssistantId = secondMedAssistId,
                OrderlyId = orderlyId,
                DriverId = driverId,
                DateTimeStart = DateTime.Now,
                StationName = department,
                BrigadeType = brigadeType,
            });

            ClearFields();
        }

        private void ClearFields()
        {
            textBrigadeNumber.Text = "";
            comboBrigadeType.Text = "";
            comboDoktor.Text = "";
            comboMedcalAssistant1.Text = "";
            comboMedcalAssistant2.Text = "";
            comboOrderly.Text = "";
            comboDriver.Text = "";
            comboDepartment.Text = "";
        }

        private void RemoveBrigade_Cliick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Подтвердите ваш выбор", "Удаление бригады", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var brigadeNumber = textBrigadeNumber.Text;
                    if (string.IsNullOrEmpty(brigadeNumber))
                    {
                        throw new ArgumentException();
                    }

                    var brigadeForRemove = _brigades.First(e => e.Number == uint.Parse(brigadeNumber));
                    _brigades.Remove(brigadeForRemove);

                    ClearFields();
                }

            }
            catch
            {
                MessageBox.Show("Не верно введен номер бригады", "Ошибка");
            }
        }

        private void TextBrigadeNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            var brigadeNumber = textBrigadeNumber.Text;
            if (!string.IsNullOrEmpty(brigadeNumber))
            {
                var selectedBrigade = _brigades.FirstOrDefault(e => e.Number == uint.Parse(brigadeNumber));
                if (selectedBrigade != null)
                {
                    comboBrigadeType.Text = selectedBrigade.BrigadeType == 0 ? "Неотложная" : "Реанимационная";
                    comboDoktor.Text = selectedBrigade.DoctorFIO;
                    comboMedcalAssistant1.Text = selectedBrigade.FirstMedicalAssistantFIO;
                    comboMedcalAssistant2.Text = selectedBrigade.SecondMedicalAssistantFIO;
                    comboOrderly.Text = selectedBrigade.OrderlyFIO;
                    comboDriver.Text = selectedBrigade.DriverFIO;
                    comboDepartment.Text = selectedBrigade.StationName;
                }
            }
        }
    }
}
