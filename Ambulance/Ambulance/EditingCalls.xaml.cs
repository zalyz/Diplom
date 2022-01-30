using Ambulance.Classes;
using System;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Text.RegularExpressions;
using Ambulance.DBAccess;
using System.Windows.Controls;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for EditingCalls.xaml
    /// </summary>
    public partial class EditingCalls : Window
    {
        private readonly string _dispatcherFIO;

        private int _selectedCall = -1;

        private AmbulanceDBContext _context = new AmbulanceDBContext();

        public EditingCalls(string dispatcherFIO)
        {
            InitializeComponent();
            _dispatcherFIO = dispatcherFIO;
            gridEditCalls.ItemsSource = MainWindow.AmbulanceCallsForProcessing;
            comboStreet.ItemsSource = ServerService.GetStreets();
            comboDiagnosis.ItemsSource = ServerService.GetDiagnoses();
            comboPlace.ItemsSource = ServerService.GetPlaces();
            comboRezault.ItemsSource = ServerService.GetResults();
            UpdateNumberOfCalls();
        }

        private void UpdateNumberOfCalls()
        {
            lableCountOfCalls.Content = MainWindow.AmbulanceCallsForProcessing.Count;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SetCall(ProcessedCall processedCall)
        {
            textCallNumber.Text = processedCall.CallNumber.ToString();
            textDateComeback.Text = processedCall.AmbulanceBrigade.ActionDate;
            textTimeComeback.Text = processedCall.AmbulanceBrigade.ActionTime;
            textDateTransfer.Text = processedCall.TransferDateTime.ToString("dd.MM.yyyy");
            textTimeTransfer.Text = processedCall.TransferDateTime.ToString("hh:mm");
            textBrigadeNumber.Text = processedCall.AmbulanceBrigade.Number.ToString();
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

        private void TextCallNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var callNumber = double.Parse(textCallNumber.Text);
                var call = MainWindow.AmbulanceCallsForProcessing.Where(e => e.CallNumber == callNumber).FirstOrDefault();
                if (call != null)
                {
                    _selectedCall = MainWindow.AmbulanceCallsForProcessing.IndexOf(call);
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
            textTreatment.Text = "";

            _selectedCall = -1;
        }

        private void ProcessingButton_Click(object sender, RoutedEventArgs e)
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
                var diagnosis = comboDiagnosis.Text;
                var result = comboRezault.Text;
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
                double age = 0;
                if (!string.IsNullOrEmpty(textAge.Text))
                {
                    try
                    {
                        age = double.Parse(textAge.Text);
                    }
                    catch
                    {
                        throw new ArgumentException("Возраст введен не верно");
                    }
                }

                var notes = textNotes.Text;

                var processedCall = MainWindow.AmbulanceCallsForProcessing.Where(e => e.CallNumber == callNumber).FirstOrDefault();
                if (processedCall != null)
                {
                    var samePatient = _context.Patients.Where(
                        e => e.FIO == fio && e.Age == age && e.Street == street && e.HouseNumber == houseNumber && e.FlatNumber == flatNumber && e.Gender == gender
                        ).ToList();
                    if (samePatient.Any())
                    {
                        processedCall.Patient = samePatient.First();
                    }
                    else
                    {
                        processedCall.Patient = new Patient { FIO = fio, Age = age, Street = street, HouseNumber = houseNumber, FlatNumber = flatNumber, Gender = gender };

                    }

                    processedCall.Diagnosis = diagnosis;
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
                    processedCall.ProcessingDispatcher = _dispatcherFIO;
                    processedCall.KilometrageBefor = kmBefore;
                    processedCall.KilometrageAfter = kmAfter;
                    processedCall.Place = place;
                    processedCall.CallNotes = notes;
                    processedCall.Treatment = textTreatment.Text;
                }

                ClearButton_Click(null,null);
                MessageBox.Show("Вызов обработан");
                _context.ProcessedCalls.AddAsync(processedCall);
                _context.SaveChangesAsync();
                MainWindow.AmbulanceCallsForProcessing.RemoveAt(_selectedCall);
                UpdateNumberOfCalls();
            }
            catch (ArgumentException argException)
            {
                MessageBox.Show(argException.Message);
            }
        }

        private void TreatmentTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var treatmentWindow = new TreatmentWindow();
            treatmentWindow.Owner = this;
            treatmentWindow.ShowDialog();
            textTreatment.Text = treatmentWindow.textTreatment.Text;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        private void ButtonIncidentalCall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textCallNumber.Text))
                {
                    var InputCallWindow = new InputCall(WindowTypes.EnterIncidentalCall, _dispatcherFIO, int.Parse(textCallNumber.Text));
                    InputCallWindow.Owner = this;
                    InputCallWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Номер вызова не введен.");
                }
            }
            catch
            {

            }
        }

        private void gridEditCalls_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var indexOfSelectedSell = gridEditCalls.SelectedIndex;
            if (indexOfSelectedSell >= 0)
            {
                SetCall(MainWindow.AmbulanceCallsForProcessing[indexOfSelectedSell]);
                _selectedCall = gridEditCalls.SelectedIndex;
            }
        }
    }
}
