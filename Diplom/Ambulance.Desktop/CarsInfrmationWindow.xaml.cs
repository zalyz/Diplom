using System.Collections.Generic;
using System.Windows;
using Ambulance.CallApi.Client;
using Ambulance.Domain.Models;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for CarsInfrmationWindow.xaml
    /// </summary>
    public partial class CarsInfrmationWindow : Window
    {
        public CarsInfrmationWindow(ICallApiClient callApiClient, int brigadeId)
        {
            InitializeComponent();
            var calls = callApiClient.BrigadeOperations.GetCalls(brigadeId).GetAwaiter().GetResult();
            var brigade = callApiClient.BrigadeOperations.GetBrigade(brigadeId).GetAwaiter().GetResult();
            gridCalls.ItemsSource = calls;
            lableDoktor.Content = brigade.DoctorFIO;
            lableMedAssistant1.Content = brigade.FirstMedicalAssistantFIO;
            lableMedAssistant2.Content = brigade.SecondMedicalAssistantFIO;
            lableOrderly.Content = brigade.OrderlyFIO;
            lableDriver.Content = brigade.DriverFIO;
            lableStationName.Content = brigade.StationName;
            lableType.Content = brigade.BrigadeType;
            lableNumberOfCalls.Content = calls.Count;
        }
    }
}
