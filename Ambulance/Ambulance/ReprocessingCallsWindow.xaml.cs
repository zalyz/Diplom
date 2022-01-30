using System.Windows;
using System.Linq;
using Ambulance.DBAccess;
using Ambulance.Classes;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for ReprocessingCallsWindow.xaml
    /// </summary>
    public partial class ReprocessingCallsWindow : Window
    {

        private AmbulanceDBContext _context = new AmbulanceDBContext();
        public ReprocessingCallsWindow()
        {
            InitializeComponent();
        }

        private void TextCallNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var callNumber = int.Parse(textCallNumber.Text);
                var call = _context.ProcessedCalls.Where(e => e.CallNumber == callNumber).FirstOrDefault();
                if (call != null)
                {
                    SetCall(call);
                }
            }
            catch
            {

            }
        }

        private void SetCall(ProcessedCall processedCall)
        {
            textDateComeback.Text = processedCall.AmbulanceBrigade.ActionDate;
            textTimeComeback.Text = processedCall.AmbulanceBrigade.ActionTime;
            textDateTransfer.Text = processedCall.TransferDateTime.Date.ToString("dd.mm.gggg");
            textTimeTransfer.Text = processedCall.TransferDateTime.ToString("hh:mm");
            lableBrigadeNumber.Content = processedCall.AmbulanceBrigade.Number.ToString();
            comboDiagnosis.Text = processedCall.Diagnosis;
            textDoktor.Text = processedCall.AmbulanceBrigade.Doktor;
            textMedAsstant1.Text = processedCall.AmbulanceBrigade.MedicalAssistants1;
            textMedAsstant2.Text = processedCall.AmbulanceBrigade.MedicalAssistants2;
            textOrderly.Text = processedCall.AmbulanceBrigade.Orderly;
            textDriver.Text = processedCall.AmbulanceBrigade.Driver;
            comboStreet.Text = processedCall.Patient.Street;
            textHouseNumber.Text = processedCall.Patient.HouseNumber.ToString();
            textFlatNumber.Text = processedCall.Patient.FlatNumber.ToString();
            textFIO.Text = processedCall.Patient.FIO;
            textAge.Text = processedCall.Patient.Age.ToString();
            textNotes.Text = processedCall.CallNotes;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TreatmentTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var treatmentWindow = new TreatmentWindow();
            treatmentWindow.Owner = this;
            treatmentWindow.ShowDialog();
            textTreatment.Text = treatmentWindow.textTreatment.Text;
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
            lableBrigadeNumber.Content= "";
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
        }

        private ProcessedCall GetReprocessedCall()
        {
            try
            {
                var callNumber = uint.Parse(textCallNumber.Text);
                var processedCall = _context.ProcessedCalls.Where(e => e.CallNumber == callNumber).FirstOrDefault();
                if (processedCall != null)
                {
                    var dateOfComeback = textDateComeback.Text;
                    var TimeOfComeback = textTimeComeback.Text;
                    var dateOfTransfer = textDateTransfer.Text;
                    var timeOfTransfer = textTimeTransfer.Text;
                    var dateOfArival = textDateArival.Text;
                    var timeOfArival = textTimeArival.Text;
                    var dateOfDeparture = textDateDeparture.Text;
                    var timeOfDeparture = textTimeDeparture.Text;
                    var diagnosis = comboDiagnosis.Text;
                    var result = comboRezault.Text;
                    var kmBefore = int.Parse(textKMBefore.Text);
                    var kmAfter = int.Parse(textKMAfter.Text);
                    string gender = "";
                    if (checkGender.IsChecked == true)
                    {
                        if (checkMale.IsChecked == true)
                        {
                            gender = "МУЖСКОЙ";
                        }
                        else
                        {
                            if (chekFamale.IsChecked == true)
                            {
                                gender = "ЖЕНСКИЙ";
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

                    var place = comboPlace.Text;
                    var doktor = textDoktor.Text;
                    var medAsstant1 = textMedAsstant1.Text;
                    var medAsstant2 = textMedAsstant2.Text;
                    var orderly = textOrderly.Text;
                    var driver = textDriver.Text;
                    var street = comboStreet.Text;
                    var houseNumber = textHouseNumber.Text;
                    var flatNumber = textFlatNumber.Text;
                    var fio = textFIO.Text;
                    var age = double.Parse(textAge.Text);
                    var notes = textNotes.Text;

                    processedCall.Patient.FIO = fio;
                    processedCall.Patient.Age = age;
                    processedCall.Diagnosis = diagnosis;
                    processedCall.Patient.Street = street;
                    processedCall.Patient.HouseNumber = houseNumber;
                    processedCall.Patient.FlatNumber = flatNumber;
                    processedCall.Patient.Gender = gender;
                    processedCall.AmbulanceBrigade.Doktor = doktor;
                    processedCall.AmbulanceBrigade.MedicalAssistants1 = medAsstant1;
                    processedCall.AmbulanceBrigade.MedicalAssistants2 = medAsstant2;
                    processedCall.AmbulanceBrigade.Orderly = orderly;
                    processedCall.AmbulanceBrigade.Driver = driver;
                    processedCall.Results = result;
                    processedCall.TransferDateTime = DateTime.Parse(dateOfTransfer + " " + timeOfTransfer);
                    processedCall.ArrivalDateTime = DateTime.Parse(dateOfArival + " " + timeOfArival);
                    processedCall.DepartureDateTime = DateTime.Parse(dateOfDeparture + " " + timeOfDeparture);
                    processedCall.ComeBackDateTime = DateTime.Parse(dateOfComeback + " " + TimeOfComeback);
                    processedCall.KilometrageBefor = kmBefore;
                    processedCall.KilometrageAfter = kmAfter;
                    processedCall.Place = place;
                    processedCall.CallNotes = notes;
                    processedCall.Treatment = textTreatment.Text;
                    ClearButton_Click(null, null);
                    return processedCall;
                }
                else
                {
                    throw new ArgumentException("Нет вызова с таким номером.");
                }
            }
            catch (ArgumentException argException)
            {
                MessageBox.Show(argException.Message);
                return null;
            }
        }

        private IncidentalCall GetIncidentalCall()
        {
            try
            {
                var incidentalCallNumber = double.Parse(textCallNumber.Text);
                var incidentalCall = _context.IncidentalCalls.Where(e => e.CallNumber == incidentalCallNumber).FirstOrDefault();
                if (incidentalCall != null)
                {
                    var dateOfComeback = textDateComeback.Text;
                    var TimeOfComeback = textTimeComeback.Text;
                    var dateOfTransfer = textDateTransfer.Text;
                    var timeOfTransfer = textTimeTransfer.Text;
                    var dateOfArival = textDateArival.Text;
                    var timeOfArival = textTimeArival.Text;
                    var dateOfDeparture = textDateDeparture.Text;
                    var timeOfDeparture = textTimeDeparture.Text;
                    var diagnosis = comboDiagnosis.Text;
                    var result = comboRezault.Text;
                    var kmBefore = int.Parse(textKMBefore.Text);
                    var kmAfter = int.Parse(textKMAfter.Text);
                    string gender = "";
                    if (checkGender.IsChecked == true)
                    {
                        if (checkMale.IsChecked == true)
                        {
                            gender = "МУЖСКОЙ";
                        }
                        else
                        {
                            if (chekFamale.IsChecked == true)
                            {
                                gender = "ЖЕНСКИЙ";
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

                    var place = comboPlace.Text;
                    var doktor = textDoktor.Text;
                    var medAsstant1 = textMedAsstant1.Text;
                    var medAsstant2 = textMedAsstant2.Text;
                    var orderly = textOrderly.Text;
                    var driver = textDriver.Text;
                    var street = comboStreet.Text;
                    var houseNumber = textHouseNumber.Text;
                    var flatNumber = textFlatNumber.Text;
                    var fio = textFIO.Text;
                    var age = double.Parse(textAge.Text);
                    var notes = textNotes.Text;

                    incidentalCall.Patient.FIO = fio;
                    incidentalCall.Patient.Age = age;
                    incidentalCall.Diagnosis = diagnosis;
                    incidentalCall.Patient.Street = street;
                    incidentalCall.Patient.HouseNumber = houseNumber;
                    incidentalCall.Patient.FlatNumber = flatNumber;
                    incidentalCall.Patient.Gender = gender;
                    incidentalCall.AmbulanceBrigade.Doktor = doktor;
                    incidentalCall.AmbulanceBrigade.MedicalAssistants1 = medAsstant1;
                    incidentalCall.AmbulanceBrigade.MedicalAssistants2 = medAsstant2;
                    incidentalCall.AmbulanceBrigade.Orderly = orderly;
                    incidentalCall.AmbulanceBrigade.Driver = driver;
                    incidentalCall.Results = result;
                    incidentalCall.TransferDateTime = DateTime.Parse(dateOfTransfer + " " + timeOfTransfer);
                    incidentalCall.ArrivalDateTime = DateTime.Parse(dateOfArival + " " + timeOfArival);
                    incidentalCall.DepartureDateTime = DateTime.Parse(dateOfDeparture + " " + timeOfDeparture);
                    incidentalCall.ComeBackDateTime = DateTime.Parse(dateOfComeback + " " + TimeOfComeback);
                    incidentalCall.KilometrageBefor = kmBefore;
                    incidentalCall.KilometrageAfter = kmAfter;
                    incidentalCall.Place = place;
                    incidentalCall.CallNotes = notes;
                    incidentalCall.Treatment = textTreatment.Text;

                    ClearButton_Click(null, null);
                    return incidentalCall;
                }
                else
                {
                    throw new ArgumentException("Попутного вызова с таким номером не существует.");
                }
            }
            catch (ArgumentException argException)
            {
                MessageBox.Show(argException.Message);
                return null;
            }
            catch (FormatException)
            {
                MessageBox.Show("Не верный формат номера.");
                return null;
            }
        }

        private void ReprocessingButton_Click(object sender, RoutedEventArgs e)
        {
            var callNumber = textCallNumber.Text;
            if (!string.IsNullOrEmpty(callNumber))
            {
                if (!callNumber.Contains(','))
                {
                    var reprocessedCall = GetReprocessedCall();
                    if (reprocessedCall != null)
                    {
                        _context.Update(reprocessedCall);
                    }
                }
                else
                {
                    var reprocessedIncidentalCall = GetIncidentalCall();
                    if (reprocessedIncidentalCall != null)
                    {
                        _context.Update(reprocessedIncidentalCall);
                    }
                }
                _context.SaveChangesAsync();
                        MessageBox.Show("Запись о вызове изменена.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var callNumber = textCallNumber.Text;
            if (!string.IsNullOrEmpty(callNumber))
            {
                if (!callNumber.Contains(','))
                {
                    var processedCall = _context.ProcessedCalls.Where(e => e.CallNumber == uint.Parse(callNumber)).FirstOrDefault();
                    if (processedCall != null)
                    {
                        _context.Remove(processedCall);
                    }
                }
                else
                {
                    var incidentalCall = _context.IncidentalCalls.Where(e => e.CallNumber == double.Parse(callNumber)).FirstOrDefault();
                    if (incidentalCall != null)
                    {
                        _context.Remove(incidentalCall);
                    }
                }

                _context.SaveChangesAsync();
                MessageBox.Show("Запись о вызове изменена.");
            }
        }
    }
}
