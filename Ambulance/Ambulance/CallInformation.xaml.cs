using System.Windows;
using Ambulance.Classes;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for CallInformation.xaml
    /// </summary>
    public partial class CallInformation : Window
    {
        public CallInformation(AmbulanceCall call)
        {
            InitializeComponent();

            lableCallNumber.Content = call.CallNumber;
            lableCallReceivingDate.Content = call.DateTimeReception.ToString("dd.MM.yyyy");
            lableCallReceivingTime.Content = call.DateTimeReception.ToString("hh:mm");
            lableFIOInformation.Content = call.Patient.FIO;
            lableAgeInformation.Content = call.Patient.Age;
            lableStreetInformation.Content = call.Patient.Street;
            lableHouseNumberInformation.Content = call.Patient.HouseNumber;
            lableFlatNumberInformation.Content = call.Patient.FlatNumber;
            lableDiagnosis.Content = call.Diagnosis;
            lableWhoCalled.Content = call.WhoCalled;
            lableUrgency.Content = call.Type;
            lableDispatcherAccepted.Content = call.ReceivingDispatcher;
            lableDispatcherPassed.Content = call.TransferringDispatcher;
            textboxCallInformation.Text = call.CallNotes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
