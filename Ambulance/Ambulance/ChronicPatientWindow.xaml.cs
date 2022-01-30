using System;
using System.Windows;
using System.Linq;
using Ambulance.DBAccess;
using Ambulance.Classes;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for ChronicPatientWindow.xaml
    /// </summary>
    public partial class ChronicPatientWindow : Window
    {
        private AmbulanceDBContext _context = new AmbulanceDBContext();

        public ChronicPatientWindow()
        {
            InitializeComponent();
            comboStreet.ItemsSource = ServerService.GetStreets();
            comboDiagnosis.ItemsSource = ServerService.GetDiagnoses();
            gridChrnicPatient.ItemsSource = _context.ChronicPatients.ToList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var fio = textFIO.Text;
            var diagnosis = comboDiagnosis.Text;
            var street = comboStreet.Text;
            var houseNumber = textHouseNumber.Text;
            var flatNumber = textFlatNumber.Text;
            try
            {
                var listOfChronicPatient = _context.ChronicPatients.ToList();
                if (!string.IsNullOrEmpty(fio) && listOfChronicPatient.Any())
                {
                    listOfChronicPatient = listOfChronicPatient.Where(
                        e => e.FIO.ToUpper().Contains(fio.ToUpper())
                        ).ToList();
                }

                if (!string.IsNullOrEmpty(diagnosis) && listOfChronicPatient.Any())
                {
                    listOfChronicPatient = listOfChronicPatient.Where(
                        e => e.Diagnosis.ToUpper().Contains(diagnosis.ToUpper())
                        ).ToList();
                }

                if (!string.IsNullOrEmpty(street) && listOfChronicPatient.Any())
                {
                    listOfChronicPatient = listOfChronicPatient.Where(
                        e => e.Street.ToUpper().Contains(street.ToUpper())
                        ).ToList();
                }

                if (!string.IsNullOrEmpty(houseNumber) && listOfChronicPatient.Any())
                {
                    listOfChronicPatient = listOfChronicPatient.Where(
                        e => e.HouseNumber.ToUpper().Contains(houseNumber.ToUpper())
                        ).ToList();
                }

                if (!string.IsNullOrEmpty(flatNumber) && listOfChronicPatient.Any())
                {
                    listOfChronicPatient = listOfChronicPatient.Where(
                        e => e.FlatNumber.ToUpper().Contains(flatNumber.ToUpper())
                        ).ToList();
                }

                gridChrnicPatient.ItemsSource = listOfChronicPatient;
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Данные введены не верно");
            }
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedPatient = (ChronicPatient)gridChrnicPatient.SelectedItem;

                if (selectedPatient != null)
                {
                    var patient = new Patient
                    {   
                        FIO = selectedPatient.FIO,
                        Age = selectedPatient.Age,
                        Street = selectedPatient.Street,
                        HouseNumber = selectedPatient.HouseNumber,
                        FlatNumber = selectedPatient.FlatNumber,
                        Gender = selectedPatient.Gender
                    };

                    var ambulanceCall = new AmbulanceCall(patient, DateTime.Now, selectedPatient.Diagnosis, selectedPatient.Notes,
                        selectedPatient.WhoCalled, selectedPatient.Urgency);
                    MainWindow.AddAmbulanceCall(ambulanceCall);
                }
            }
            catch
            {

            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _context.DisposeAsync();
            this.Close();
        }
    }
}
