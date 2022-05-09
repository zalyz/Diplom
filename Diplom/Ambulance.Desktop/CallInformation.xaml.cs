using System.Windows;
using Ambulance.Domain.Models;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for CallInformation.xaml
    /// </summary>
    public partial class CallInformation : Window
    {
        public CallInformation(CallOfficeInfo call)
        {
            InitializeComponent();

            lableCallNumber.Content = call.CallNumber;
            lableCallReceivingDate.Content = call.DateTimeReception.ToString("dd.MM.yyyy");
            lableCallReceivingTime.Content = call.DateTimeReception.ToString("hh:mm");
            lableFIOInformation.Content = call.FIO;
            lableAgeInformation.Content = call.Age;
            lableStreetInformation.Content = call.Street;
            lableHouseNumberInformation.Content = call.HouseNumber;
            lableFlatNumberInformation.Content = call.FlatNumber;
            lableDiagnosis.Content = call.Diagnosis;
            lableWhoCalled.Content = call.Caller;
            lableUrgency.Content = call.Type.ToString();
            lableDispatcherAccepted.Content = call.DispatcherId;
            lableDispatcherPassed.Content = call.TransferingDispatcherId;
            textboxCallInformation.Text = call.CallNotes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
