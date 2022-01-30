using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Ambulance.Classes;
using System.Linq;
using Ambulance.DBAccess;
using System.Text.RegularExpressions;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        private ObservableCollection<AmbulanceBrigade> _brigades;

        private static AmbulanceDBContext _context;

        public DataWindow(ObservableCollection<AmbulanceBrigade> brigades)
        {
            InitializeComponent();
            _context = new AmbulanceDBContext();
            _brigades = brigades;
            dateAutoBrigade.SelectedDate = DateTime.Now;
            comboBrigadeType.ItemsSource = ServerService.GetBrigadeTypes();
            comboDoktor.ItemsSource = _context.Doktors.ToList();
            comboMedcalAssistant1.ItemsSource = _context.MedicalAssistants.ToList();
            comboMedcalAssistant2.ItemsSource = comboMedcalAssistant1.ItemsSource;
            comboOrderly.ItemsSource = _context.Orderlies.ToList();
            comboDriver.ItemsSource = _context.Drivers.ToList();
            comboDepartment.ItemsSource = ServerService.GetDepartments();

            UpdateGridChronicPatients();
            comboStreet.ItemsSource = ServerService.GetStreets();
            comboReason.ItemsSource = ServerService.GetDiagnoses();
            comboWho.ItemsSource = ServerService.GetCallers();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void AddBrigade_Click(object sender, RoutedEventArgs e)
        {
            var brigadeNumber = uint.Parse(textBrigadeNumber.Text);
            if (!_brigades.Where(e => e.Number == brigadeNumber).Any())
            {
                var medicalAssistans = new string[2];

                var brgadeType = comboBrigadeType.Text;
                var doktor = comboDoktor.Text;
                medicalAssistans[0] = comboMedcalAssistant1.Text;
                medicalAssistans[1] = comboMedcalAssistant2.Text;
                var orderly = comboOrderly.Text;
                var driver = comboDriver.Text;
                var department = comboDepartment.Text;

                var brigade = new AmbulanceBrigade
                {
                    Number = brigadeNumber,
                    Doktor = doktor,
                    MedicalAssistants1 = medicalAssistans[0],
                    MedicalAssistants2 = medicalAssistans[1],
                    Orderly = orderly,
                    Driver = driver,
                    BrigadeType = brgadeType,
                    StationName = department,
                    ActionTime = DateTime.Now.ToString("hh:mm"),
                    ActionDate = DateTime.Now.ToString("dd.MM.yyyy")
                };

                _brigades.Add(brigade);
                ClearFields();

            }
            else
            {
                MessageBox.Show("Бригада с таким номером уже принята к работе", "Ошибка");
            }
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
                    comboBrigadeType.Text = selectedBrigade.BrigadeType;
                    comboDoktor.Text = selectedBrigade.Doktor;
                    comboMedcalAssistant1.Text = selectedBrigade.MedicalAssistants1.ToString();
                    comboMedcalAssistant2.Text = selectedBrigade.MedicalAssistants2.ToString();
                    comboOrderly.Text = selectedBrigade.Orderly.ToString();
                    comboDriver.Text = selectedBrigade.Driver.ToString();
                    comboDepartment.Text = selectedBrigade.StationName;
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _context.DisposeAsync();
        }

        private void UpdateGridChronicPatients()
        {
            var chronicPatients = _context.ChronicPatients.ToList();
            gridChronicPatients.ItemsSource = null;
            gridChronicPatients.ItemsSource = chronicPatients;
        }

        private void AddChronicPatients_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fio = textFio.Text;
                var street = comboStreet.Text;
                var houseNumber = textHouse.Text;
                var flatNumber = textFlat.Text;
                var age = double.Parse(textAge.Text);
                var reason = comboReason.Text;
                var gender = comboGender.Text;
                var urgency = comboUrgency.Text;
                var whoCalled = comboWho.Text;
                var notes = textNotes.Text;

                var chronicPatient = new ChronicPatient
                {
                    FIO = fio,
                    Street = street,
                    HouseNumber = houseNumber,
                    FlatNumber = flatNumber,
                    Age = age,
                    Diagnosis = reason,
                    Gender = gender,
                    Urgency = urgency,
                    WhoCalled = whoCalled,
                    Notes = notes
                };

                _context.ChronicPatients.AddAsync(chronicPatient);
                _context.SaveChanges();
                UpdateGridChronicPatients();
            }
            catch
            {

            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            textFio.Text = "";
            comboStreet.Text = "";
            textHouse.Text = "";
            textFlat.Text = "";
            textAge.Text = "";
            comboReason.Text = "";
            comboGender.Text = "";
            comboWho.Text = "";
            textNotes.Text = "";
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var index = gridChronicPatients.SelectedIndex;
            if (index >= 0)
            {
                var removedPatient = _context.ChronicPatients.Skip(index).First();
                _context.ChronicPatients.Remove(removedPatient);
                _context.SaveChanges();
                UpdateGridChronicPatients();
            }
        }
    }
}
