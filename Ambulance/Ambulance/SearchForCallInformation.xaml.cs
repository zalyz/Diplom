using Ambulance.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using Ambulance.DBAccess;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for SearchInformationAboutCall.xaml
    /// </summary>
    public partial class SearchInformationAboutCall : Window
    {
        private AmbulanceDBContext _context = new AmbulanceDBContext();

        public SearchInformationAboutCall()
        {
            InitializeComponent();
            dateFrom.SelectedDate = DateTime.Parse("1.1." + DateTime.Now.Year);
            dateTo.SelectedDate = DateTime.Now;
            isAllTime.IsChecked = true;
            dateFrom.IsEnabled = false;
            dateTo.IsEnabled = false;
        }

        private void IsAllTime_Click(object sender, RoutedEventArgs e)
        {
            if (isAllTime.IsChecked == false)
            {
                dateFrom.IsEnabled = true;
                dateTo.IsEnabled = true;
            }
            else
            {
                dateFrom.IsEnabled = false;
                dateTo.IsEnabled = false;
            }
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var callNumber = textCallnumber.Text;
                var fio = textFIO.Text;
                var street = comboStreet.Text;
                var houseNumber = textHouseNumber.Text;
                var flatNumber = textFlatNumber.Text;
                var diagnosis = comboDiagnosis.Text;
                var result = comboResult.Text;
                var startDate = dateFrom.SelectedDate;
                var endDate = dateTo.SelectedDate;
                List<Call> listOfCalls;
                if (isAllTime.IsChecked == true)
                {
                    listOfCalls = _context.ProcessedCalls.ToList<Call>();
                    var listOfIncidentalCalls = _context.IncidentalCalls.ToList<Call>();
                    listOfCalls.AddRange(listOfIncidentalCalls);
                }
                else
                {
                    listOfCalls = _context.ProcessedCalls.Where(
                        e => e.DateTimeReception.Date >= startDate.Value.Date && e.DateTimeReception <= endDate.Value.Date
                        ).ToList<Call>();
                    var listOfIncidentalCalls = _context.IncidentalCalls.Where(
                        e => e.DateTimeReception.Date >= startDate.Value.Date && e.DateTimeReception <= endDate.Value.Date
                        ).ToList<Call>();
                    if (listOfIncidentalCalls.Any())
                    {
                        listOfCalls.AddRange(listOfIncidentalCalls);
                    }
                }

                if (!string.IsNullOrEmpty(callNumber) && listOfCalls.Any())
                {
                    listOfCalls = listOfCalls.Where(e => e.CallNumber == double.Parse(callNumber)).ToList();
                }

                if (!string.IsNullOrEmpty(fio) && listOfCalls.Any())
                {
                    listOfCalls = listOfCalls.Where(e => e.Patient.FIO.ToUpper().Contains(fio.ToUpper())).ToList();
                }

                if (!string.IsNullOrEmpty(street) && listOfCalls.Any())
                {
                    listOfCalls = listOfCalls.Where(e => e.Patient.Street.ToUpper().Contains(street.ToUpper())).ToList();
                }

                if (!string.IsNullOrEmpty(houseNumber) && listOfCalls.Any())
                {
                    listOfCalls = listOfCalls.Where(e => e.Patient.HouseNumber.ToUpper().Contains(houseNumber.ToUpper())).ToList();
                }

                if (!string.IsNullOrEmpty(flatNumber) && listOfCalls.Any())
                {
                    listOfCalls.Where(e => e.Patient.FlatNumber.ToUpper().Contains(flatNumber.ToUpper())).ToList();
                }

                if (!string.IsNullOrEmpty(diagnosis) && listOfCalls.Any())
                {
                    listOfCalls.Where(e => e.Diagnosis.ToUpper().Contains(diagnosis.ToUpper())).ToList();
                }

                if (!string.IsNullOrEmpty(result) && listOfCalls.Any())
                {
                    listOfCalls = listOfCalls.Where(e => e.Results.ToUpper().Contains(result.ToUpper())).ToList();
                }

                if (listOfCalls.Any())
                {
                    listOfCalls.ForEach(e => e.Patient = _context.Patients.Where(p => p.Id == e.PatientId).First());
                    gridCalls.ItemsSource = listOfCalls;
                    lableFoundRecordNumber.Content = listOfCalls.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridCalls_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ShowFullCallInformation();
        }

        private void ShowFullCallInformation()
        {
            var selectedCalls = gridCalls.SelectedItem;
            if (selectedCalls != null)
            {
                var fullCallInformation = new FullCallInformationWindow((Call)selectedCalls);
                fullCallInformation.Owner = this;
                fullCallInformation.ShowDialog();
            }
        }

        private void ButtonShowRecord_Click(object sender, RoutedEventArgs e)
        {
            ShowFullCallInformation();
        }
    }
}
