using System;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using Ambulance.Domain.Models;
using Ambulance.CallApi.Client;
using Ambulance.ServiceAPI.Client;
using System.Collections.Generic;
using Ambulance.Domain.Models.Enums;
using Ambulance.Domain.Models.ServiceModels;
using System.Threading.Tasks;
using Ambulance.Domain.Models.Call;
using Ambulance.Domain.Models.Patients;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for EditingCalls.xaml
    /// </summary>
    public partial class EditingCalls : Window
    {
        private readonly Dispatcher _dispatcher;

        private int _selectedCall = -1;

        private int _callsCount = 0;

        private List<CallFullOfficeInfo> _calls = new();

        private List<Drug> _treatment = new();

        private readonly ICallApiClient _apiClient;

        private readonly IServiceApiClient _serviceApiClient;

        public EditingCalls(Dispatcher dispatcher, ICallApiClient callApiClient, IServiceApiClient serviceApiClient)
        {
            _apiClient = callApiClient;
            _serviceApiClient = serviceApiClient;
            InitializeComponent();
            _dispatcher = dispatcher;
            _calls = callApiClient.CallOperations.GetPending().GetAwaiter().GetResult();
            _callsCount = _calls.Count;
            gridEditCalls.ItemsSource = _calls;
            comboStreet.ItemsSource = serviceApiClient.ServiceResource.GetStreets().GetAwaiter().GetResult();
            comboDiagnosis.ItemsSource = serviceApiClient.ServiceResource.GetDiagnosis().GetAwaiter().GetResult();
            comboPlace.ItemsSource = serviceApiClient.ServiceResource.GetPlaces().GetAwaiter().GetResult();
            comboRezault.ItemsSource = serviceApiClient.ServiceResource.GetResults().GetAwaiter().GetResult();
            UpdateNumberOfCalls();
        }

        private void UpdateNumberOfCalls()
        {
            lableCountOfCalls.Content = _callsCount;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SetCall(CallFullOfficeInfo processedCall)
        {
            textCallNumber.Text = processedCall.CallNumber.ToString();
            textDateTransfer.Text = processedCall.TransferDateTime.ToString("dd.MM.yyyy");
            textTimeTransfer.Text = processedCall.TransferDateTime.ToString("hh:mm");
            textBrigadeNumber.Text = processedCall.BrigadeNumber.ToString();
            comboDiagnosis.Text = processedCall.DiagnosisName;
            textDoktor.Text = processedCall.DoktorFIO;
            textMedAsstant1.Text = processedCall.FirstMedicalAssistantFIO;
            textMedAsstant2.Text = processedCall.SecondMedicalAssistantFIO;
            textOrderly.Text = processedCall.OrderlyFIO;
            textDriver.Text = processedCall.DriverFIO;
            comboStreet.Text = processedCall.Street;
            textHouseNumber.Text = processedCall.HouseNumber;
            textFlatNumber.Text = processedCall.FlatNumber;
            textFIO.Text = processedCall.FIO;
            textAge.Text = processedCall.Age.ToString();
            textNotes.Text = processedCall.CallNotes;
        }

        private void TextCallNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var callNumber = double.Parse(textCallNumber.Text);
                var call = _calls.Where(e => e.CallNumber == callNumber).FirstOrDefault();
                if (call != null)
                {
                    _selectedCall = _calls.IndexOf(call);
                    SetCall(call);
                }
            }
            catch
            {

            }
        }

        private void CheckGender_Click(object sender, RoutedEventArgs e)
        {
            if (checkGender.IsChecked == true)
            {
                checkMale.IsEnabled = true;
                chekFamale.IsEnabled = true;
            }
            else
            {
                checkMale.IsEnabled = false;
                chekFamale.IsEnabled = false;
            }
        }

        private void CheckMale_Click(object sender, RoutedEventArgs e)
        {
            if (checkMale.IsChecked == true)
            {
                chekFamale.IsChecked = false;
            }
        }

        private void CheckFamale_Click(object sender, RoutedEventArgs e)
        {
            if (chekFamale.IsChecked == true)
            {
                checkMale.IsChecked = false;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            textDateComeback.Text = "__.__.__";
            textTimeComeback.Text = "__:__";
            textDateTransfer.Text = "__.__.__";
            textTimeTransfer.Text = "__:__";
            textDateArival.Text = "__.__.__";
            textTimeArival.Text = "__:__";
            textDateDeparture.Text = "__.__.__";
            textTimeDeparture.Text = "__:__";
            comboDiagnosis.Text = "";
            comboRezault.Text = "";
            textCallNumber.Text = "";
            textBrigadeNumber.Text = "";
            textKMBefore.Text = "";
            textKMAfter.Text = "";
            textDoktor.Text = "-";
            checkGender.IsChecked = false;
            checkMale.IsEnabled = false;
            chekFamale.IsEnabled = false;
            comboPlace.Text = "";
            textMedAsstant1.Text = "-";
            textMedAsstant2.Text = "-";
            textOrderly.Text = "-";
            textDriver.Text = "-";
            comboStreet.Text = "";
            textHouseNumber.Text = "";
            textFlatNumber.Text = "";
            textFIO.Text = "";
            textAge.Text = "";
            textNotes.Text = "";

            _selectedCall = -1;
        }

        private async void ProcessingButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var callNumber = double.Parse(textCallNumber.Text);
                var dateOfComeback = textDateComeback.Text;
                var TimeOfComeback = textTimeComeback.Text;
                var dateOfTransfer = textDateTransfer.Text;
                var timeOfTransfer = textTimeTransfer.Text;
                var dateOfArival = textDateArival.Text;
                var timeOfArival = textTimeArival.Text;
                var dateOfDeparture = textDateDeparture.Text;
                var timeOfDeparture = textTimeDeparture.Text;
                var diagnosis = (Diagnosis)comboDiagnosis.SelectedItem;
                var result = (Result)comboRezault.SelectedItem;
                var brigadeNumber = textBrigadeNumber.Text;
                int kmBefore = 0;
                int kmAfter = 0;
                if (!string.IsNullOrEmpty(textKMBefore.Text) && !string.IsNullOrEmpty(textKMAfter.Text))
                {
                    try
                    {
                        kmBefore = int.Parse(textKMBefore.Text);
                        kmAfter = int.Parse(textKMAfter.Text);

                    }
                    catch
                    {
                        throw new ArgumentException("Не верно введен километраж");
                    }
                }
                else
                {
                    MessageBox.Show("Не введен километраж бригады");
                }

                Gender gender = Gender.Male;
                if (checkGender.IsChecked == true)
                {
                    if (checkMale.IsChecked == true)
                    {
                        gender = Gender.Male;
                    }
                    else
                    {
                        if (chekFamale.IsChecked == true)
                        {
                            gender = Gender.Female;
                        }
                        else
                        {
                            throw new ArgumentException("Не выбран пол пациента");
                        }

                    }

                }
                else
                {
                    throw new ArgumentException("Не выбран пол пациента");
                }

                var place = (Place)comboPlace.SelectedItem;
                var street = (Street)comboStreet.SelectedItem;
                var houseNumber = textHouseNumber.Text;
                var flatNumber = textFlatNumber.Text;
                var fio = textFIO.Text;
                int age = 0;
                if (!string.IsNullOrEmpty(textAge.Text))
                {
                    try
                    {
                        age = int.Parse(textAge.Text);
                    }
                    catch
                    {
                        throw new ArgumentException("Возраст введен не верно");
                    }
                }

                var notes = textNotes.Text;

                var processedCall = _calls.Where(e => e.CallNumber == callNumber).First();
                var patient = new UpdatePatienRequest
                {
                    Id = processedCall.Id,
                    FIO = fio,
                    Age = age,
                    StreetId = street.Id,
                    HouseNumber = houseNumber,
                    FlatNumber = flatNumber,
                    Gender = (byte)gender,
                };

                var request = new ProcessCallRequest
                {
                    Id = processedCall.Id,
                    PatientId = patient.Id,
                    CallNumber = processedCall.CallNumber,
                    AmbulanceBrigadeId = processedCall.AmbulanceBrigadeId.Value,
                    DispatcherId = processedCall.DispatcherId,
                    PhoneNumber = string.Empty,
                    ResultId = result.Id,
                    DiagnosisId = diagnosis.Id,
                    CallerId = processedCall.CallerId,
                    DateTimeReception = processedCall.DateTimeReception,
                    TransferDateTime = DateTime.Parse(dateOfTransfer + " " + timeOfTransfer),
                    ArrivalDateTime = DateTime.Parse(dateOfArival + " " + timeOfArival),
                    DepartureDateTime = DateTime.Parse(dateOfDeparture + " " + timeOfDeparture),
                    ComeBackDateTime = DateTime.Parse(dateOfComeback + " " + TimeOfComeback),
                    TransferingDispatcherId = processedCall.TransferingDispatcherId,
                    ProcessingDispatcherid = _dispatcher.Id,
                    KilometrageBefore = kmBefore,
                    KilometrageAfter = kmAfter,
                    PlaceId = place.Id,
                    CallNotes = notes,
                    Treatment = _treatment,
                };

                await _apiClient.PatientResource.UpdatePatient(patient);
                await _apiClient.CallOperations.ProcessCall(request);

                MessageBox.Show("Вызов обработан");
                _calls.RemoveAt(_selectedCall);
                ClearButton_Click(null, null);
                UpdateNumberOfCalls();
            }
            catch (ArgumentException argException)
            {
                MessageBox.Show(argException.Message);
            }
        }

        private void TreatmentTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //var treatmentWindow = new TreatmentWindow();
            //treatmentWindow.Owner = this;
            //treatmentWindow.ShowDialog();
            //textTreatment.Text = treatmentWindow.textTreatment.Text;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        private void gridEditCalls_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var indexOfSelectedSell = gridEditCalls.SelectedIndex;
            if (indexOfSelectedSell >= 0)
            {
                SetCall(_calls[indexOfSelectedSell]);
                _selectedCall = gridEditCalls.SelectedIndex;
            }
        }

        private void Treatment_Click(object sender, RoutedEventArgs e)
        {
            var treatment = new TreatmentWindow(_serviceApiClient)
            {
                Owner = this,
            };
            treatment.ShowDialog();
            _treatment = treatment.Treatment.ToList();
        }
    }
}
