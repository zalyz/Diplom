using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using Ambulance.Classes;
using Ambulance.DBAccess;

namespace Ambulance
{
    public enum WindowTypes
    {
        EnterCall = 1,
        EnterIncidentalCall
    }

    /// <summary>
    /// Interaction logic for InputCall.xaml
    /// </summary>
    public partial class InputCall : Window
    {
        private string _dispatcherFIO;

        private AmbulanceDBContext _context = new AmbulanceDBContext();

        private WindowTypes _typeOfWindow;

        public InputCall(WindowTypes types, string dispatcher, int processedCallNumber = 0)
        {
            InitializeComponent();
            _dispatcherFIO = dispatcher;
            _typeOfWindow = types;
            
            if (types != WindowTypes.EnterCall)
            {
                textReceivingDate.Visibility = Visibility.Hidden;
                textReceivingTime.Visibility = Visibility.Hidden;
                textIncidentalCallnumber.Text = processedCallNumber.ToString() + ",";
            }

            ComboStreets.ItemsSource = ServerService.GetStreets();
            ComboDepartment.ItemsSource = ServerService.GetDepartments();
            ComboReason.ItemsSource = ServerService.GetDiagnoses();
            ComboCaller.ItemsSource = ServerService.GetCallers();
            comboPlace.ItemsSource = ServerService.GetPlaces();
            comboDiagnosis.ItemsSource = ServerService.GetDiagnoses();
            comboResult.ItemsSource = ServerService.GetResults();
            comboBrigadeType.ItemsSource = ServerService.GetBrigadeTypes();
            comboDoktor.ItemsSource = _context.Doktors.ToList();
            comboMedAssistant1.ItemsSource = _context.MedicalAssistants.ToList();
            comboMedAssistant2.ItemsSource = _context.MedicalAssistants.ToList();
            comboOrderly.ItemsSource = _context.Orderlies.ToList();
            comboDriver.ItemsSource = _context.Drivers.ToList();
        }

        private void ColseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dateOfReceiv = textReceivingDate.Text;
                var TimeOfReceiv = textReceivingTime.Text;
                var dateOfComeback = textComebackDate.Text;
                var TimeOfComeback = textComebackTime.Text;
                var dateOfTransfer = textTransferDate.Text;
                var timeOfTransfer = textTransferTime.Text;
                var dateOfArival = textArrivalDate.Text;
                var timeOfArival = textArrivalTime.Text;
                var dateOfDeparture = textDepartureDate.Text;
                var timeOfDeparture = textDepartureTime.Text;
                var diagnosis = comboDiagnosis.Text;
                var result = comboResult.Text;
                uint brigadeNumber = 0;
                if (!string.IsNullOrEmpty(textBrigadeNumber.Text))
                {
                    try
                    {
                        brigadeNumber = uint.Parse(textBrigadeNumber.Text);
                    }
                    catch
                    {
                        throw new ArgumentException("Не верно введен номер бригады");
                    }
                }
                else
                {

                }

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
                var brigadeType = comboBrigadeType.Text;
                var doktor = comboDoktor.Text;
                var medAsstant1 = comboMedAssistant1.Text;
                var medAsstant2 = comboMedAssistant2.Text;
                var orderly = comboOrderly.Text;
                var driver = comboDriver.Text;
                var street = ComboStreets.Text;
                var houseNumber = textHouseNumber.Text;
                var flatNumber = textFlatNumber.Text;
                var station = ComboDepartment.Text;
                var fio = textFIO.Text;
                var notes = textBoxNote.Text;
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

                DateTime receptionDateTime;
                DateTime transferDateTime;
                DateTime arivalDateTime;
                DateTime departureDateTime;
                DateTime combebackDateTime;
                try
                {
                    receptionDateTime = DateTime.Parse(dateOfReceiv + " " + TimeOfReceiv);
                    transferDateTime = DateTime.Parse(dateOfTransfer + " " + timeOfTransfer);
                    arivalDateTime = DateTime.Parse(dateOfArival + " " + timeOfArival);
                    departureDateTime = DateTime.Parse(dateOfDeparture + " " + timeOfDeparture);
                    combebackDateTime = DateTime.Parse(dateOfComeback + " " + TimeOfComeback);
                }
                catch
                {
                    throw new ArgumentException("Дата и время введены не верно");
                }

                if (_typeOfWindow == WindowTypes.EnterCall)
                {
                    double incidentalCallNumber;
                    if (!string.IsNullOrEmpty(textIncidentalCallnumber.Text))
                    {
                        incidentalCallNumber = double.Parse(textIncidentalCallnumber.Text);
                    }
                    else
                        throw new ArgumentException("Не введен номер вызова");

                    var processedCall = new ProcessedCall();
                    processedCall.Patient = new Patient();
                    processedCall.AmbulanceBrigade = new AmbulanceBrigade();
                    processedCall.Patient.FIO = fio;
                    processedCall.Patient.Age = age;
                    processedCall.Diagnosis = diagnosis;
                    processedCall.Patient.Street = street;
                    processedCall.Patient.HouseNumber = houseNumber;
                    processedCall.Patient.FlatNumber = flatNumber;
                    processedCall.Patient.Gender = gender;
                    processedCall.Results = result;
                    processedCall.AmbulanceBrigade.Number = brigadeNumber;
                    processedCall.AmbulanceBrigade.Doktor = doktor;
                    processedCall.AmbulanceBrigade.MedicalAssistants1 = medAsstant1;
                    processedCall.AmbulanceBrigade.MedicalAssistants2 = medAsstant2;
                    processedCall.AmbulanceBrigade.Orderly = orderly;
                    processedCall.AmbulanceBrigade.Driver = driver;
                    processedCall.AmbulanceBrigade.BrigadeType = brigadeType;
                    processedCall.AmbulanceBrigade.StationName = station;
                    processedCall.DateTimeReception = receptionDateTime;
                    processedCall.TransferDateTime = transferDateTime;
                    processedCall.ArrivalDateTime = arivalDateTime;
                    processedCall.DepartureDateTime = departureDateTime;
                    processedCall.ComeBackDateTime = combebackDateTime;
                    processedCall.TransferringDispatcher = _dispatcherFIO;
                    processedCall.ProcessingDispatcher = _dispatcherFIO;
                    processedCall.KilometrageBefor = kmBefore;
                    processedCall.KilometrageAfter = kmAfter;
                    processedCall.Place = place;
                    processedCall.CallNotes = notes;
                    processedCall.Treatment = textTreatment.Text;
                    _context.ProcessedCalls.AddAsync(processedCall);
                }
                else
                {
                    double incidentalCallNumber;
                    if (!string.IsNullOrEmpty(textIncidentalCallnumber.Text))
                    {
                        incidentalCallNumber = double.Parse(textIncidentalCallnumber.Text);
                    }
                    else
                        throw new ArgumentException("Не введен номер вызова");

                    var incidentalCall = new IncidentalCall()
                    {
                        CallNumber = incidentalCallNumber,
                        ProcessedCallId = (uint)incidentalCallNumber
                    };
                    incidentalCall.Patient = new Patient();
                    incidentalCall.AmbulanceBrigade = new AmbulanceBrigade();
                    incidentalCall.Patient.FIO = fio;
                    incidentalCall.Patient.Age = age;
                    incidentalCall.Diagnosis = diagnosis;
                    incidentalCall.Patient.Street = street;
                    incidentalCall.Patient.HouseNumber = houseNumber;
                    incidentalCall.Patient.FlatNumber = flatNumber;
                    incidentalCall.Patient.Gender = gender;
                    incidentalCall.Results = result;
                    incidentalCall.AmbulanceBrigade.Number = brigadeNumber;
                    incidentalCall.AmbulanceBrigade.Doktor = doktor;
                    incidentalCall.AmbulanceBrigade.MedicalAssistants1 = medAsstant1;
                    incidentalCall.AmbulanceBrigade.MedicalAssistants2 = medAsstant2;
                    incidentalCall.AmbulanceBrigade.Orderly = orderly;
                    incidentalCall.AmbulanceBrigade.Driver = driver;
                    incidentalCall.AmbulanceBrigade.BrigadeType = brigadeType;
                    incidentalCall.AmbulanceBrigade.StationName = station;
                    var processedCall = MainWindow.AmbulanceCallsForProcessing.Where(e => e.CallNumber == ((uint)incidentalCall.CallNumber)).FirstOrDefault();
                    if (processedCall != null)
                    {
                        incidentalCall.DateTimeReception = processedCall.DateTimeReception;
                    }
                    else
                        throw new ArgumentException();

                    incidentalCall.TransferDateTime = transferDateTime;
                    incidentalCall.ArrivalDateTime = arivalDateTime;
                    incidentalCall.DepartureDateTime = departureDateTime;
                    incidentalCall.ComeBackDateTime = combebackDateTime;
                    incidentalCall.TransferringDispatcher = _dispatcherFIO;
                    incidentalCall.ProcessingDispatcher = _dispatcherFIO;
                    incidentalCall.KilometrageBefor = kmBefore;
                    incidentalCall.KilometrageAfter = kmAfter;
                    incidentalCall.Place = place;
                    incidentalCall.CallNotes = notes;
                    incidentalCall.Treatment = textTreatment.Text;
                    _context.IncidentalCalls.AddAsync(incidentalCall);
                }

                ClearButton_Click(null, null);
                MessageBox.Show("Вызов обработан");
                _context.SaveChanges();
            }
            catch (ArgumentException argException)
            {
                MessageBox.Show(argException.Message);
            }
            catch (FormatException ed)
            {
                MessageBox.Show(ed.Message);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            textIncidentalCallnumber.Clear();
            ComboStreets.Text = "";
            textHouseNumber.Clear();
            textFlatNumber.Clear();
            textFIO.Clear();
            textAge.Clear();
            ComboDepartment.Text = "";
            ComboReason.Text = "";
            ComboCaller.Text = "";
            ComboUrgency.Text = "";
            textBoxNote.Clear();
            comboDiagnosis.Text = "";
            textTransferDate.Text = "__.__.__";
            textTransferTime.Text = "__:__";
            textArrivalDate.Text = "__.__.__";
            textArrivalTime.Text = "__:__";
            textDepartureDate.Text = "__.__.__";
            textDepartureTime.Text = "__:__";
            textComebackDate.Text = "__.__.__";
            textComebackTime.Text = "__:__";
            checkGender.IsChecked = false;
            checkMale.IsEnabled = false;
            chekFamale.IsEnabled = false;
            comboResult.Text = "";
            comboBrigadeType.Text = "";
            comboDoktor.Text = "";
            comboMedAssistant1.Text = "";
            comboMedAssistant2.Text = "";
            comboOrderly.Text = "";
            comboDriver.Text = "";
            textBrigadeNumber.Clear();
            textKMBefore.Clear();
            textKMAfter.Clear();
            textTreatment.Clear();
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
    }
}
