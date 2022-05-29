using System;
using System.Windows;
using Ambulance.CallApi.Client;
using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Call;
using Ambulance.Domain.Models.Enums;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for SearchInformationAboutCall.xaml
    /// </summary>
    public partial class SearchInformationAboutCall : Window
    {
        private readonly ICallApiClient _callApiClient;

        public SearchInformationAboutCall(ICallApiClient callApiClient)
        {
            _callApiClient = callApiClient;
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

        private async void ButtonSearch_Click(object sender, RoutedEventArgs e)
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

                var listOfCalls = await _callApiClient.CallOperations.FilterCall(new FilterRequest
                {
                    CallNumber = int.Parse(callNumber),
                    FIO = fio,
                    Street = street,
                    HouseNumber = houseNumber,
                    FlatNumber = flatNumber,
                    Diagnosis = diagnosis,
                    Result = result,
                    DateFrom = DateTime.Parse(dateFrom.Text),
                    DateTo = DateTime.Parse(dateTo.Text),
                    NumberOfElementsOnPage = null,
                    PageNumber = null,
                    CallStatus = CallStatus.Processed,
                });

                gridCalls.ItemsSource = listOfCalls;
                lableFoundRecordNumber.Content = listOfCalls.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void GridCalls_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ShowFullCallInformation();
        }

        private async void ShowFullCallInformation()
        {
            var selectedCalls = (CallFullOfficeInfo)gridCalls.SelectedItem;
            var treatments = await _callApiClient.CallOperations.GetTreatment(new GetTreatmentRequest
            {
                CallId = selectedCalls.Id,
            });
            if (selectedCalls != null)
            {
                var fullCallInformation = new FullCallInformationWindow(selectedCalls, treatments)
                {
                    Owner = this
                };
                fullCallInformation.ShowDialog();
            }
        }

        private void ButtonShowRecord_Click(object sender, RoutedEventArgs e)
        {
            ShowFullCallInformation();
        }
    }
}
