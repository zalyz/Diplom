using System.Windows;
using Ambulance.Classes;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for CarsInfrmationWindow.xaml
    /// </summary>
    public partial class CarsInfrmationWindow : Window
    {
        public CarsInfrmationWindow(AmbulanceBrigade brigade)
        {
            InitializeComponent();
            gridCalls.ItemsSource = brigade.AmbulanceCalls;
            lableDoktor.Content = brigade.Doktor.ToString();
            lableMedAssistant1.Content = brigade.MedicalAssistants1.ToString();
            lableMedAssistant2.Content = brigade.MedicalAssistants2.ToString();
            lableOrderly.Content = brigade.Orderly.ToString();
            lableDriver.Content = brigade.Driver.ToString();
            lableStationName.Content = brigade.StationName;
            lableType.Content = brigade.BrigadeType;
            lableNumberOfCalls.Content = brigade.AmbulanceCalls.Count;
        }
    }
}
