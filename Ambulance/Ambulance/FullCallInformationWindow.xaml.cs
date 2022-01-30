using System.Windows;
using Ambulance.Classes;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for FullCallInformationWindow.xaml
    /// </summary>
    public partial class FullCallInformationWindow : Window
    {
        public FullCallInformationWindow(Call call)
        {
            InitializeComponent();
            lableFIO.Content = call.Patient.FIO.ToUpper();
            lableAge.Content = call.Patient.Age;
            lableStreet.Content = call.Patient.Street;
            lableHouseNumber.Content = call.Patient.HouseNumber;
            lableFlatNumber.Content = call.Patient.FlatNumber;
            lableGender.Content = call.Patient.Gender;

            lableDiagnosis.Content = call.Diagnosis;
            lableResult.Content = call.Results;
            textTreatment.Text = call.Treatment;
            textNotes.Text = call.CallNotes;

            lableReception.Content = call.DateTimeReception.GetDateTimeFormats('F')[1];
            lableTransfer.Content = call.TransferDateTime.GetDateTimeFormats('F')[1];
            lableArival.Content = call.ArrivalDateTime.GetDateTimeFormats('F')[1];
            lableDeparture.Content = call.DepartureDateTime.GetDateTimeFormats('F')[1];
            lableComeback.Content = call.ComeBackDateTime.GetDateTimeFormats('F')[1];

            var time = (call.TransferDateTime - call.DateTimeReception);
            lableTransferingTime.Content = time.ToString(@"hh\:mm\:ss");
            time = (call.ArrivalDateTime - call.TransferDateTime);
            lableDrivingTime.Content = time.ToString(@"hh\:mm\:ss");
            time = (call.DepartureDateTime - call.ArrivalDateTime);
            lableServiceTime.Content = time.ToString(@"hh\:mm\:ss");

            lablUrgency.Content = call.CallType;
            lableDispatcherTransfered.Content = call.TransferringDispatcher;
            lableDispatcherProcessed.Content = call.ProcessingDispatcher;
            lableBrigadeNumber.Content = call.AmbulanceBrigade.Number;
            lableBrigadeType.Content = call.AmbulanceBrigade.BrigadeType;
            lableDoktor.Content = call.AmbulanceBrigade.Doktor;
            lableMedAssistant1.Content = call.AmbulanceBrigade.MedicalAssistants1;
            lableMedAssistant2.Content = call.AmbulanceBrigade.MedicalAssistants2;
            lableOrderly.Content = call.AmbulanceBrigade.Orderly;
            lableDriver.Content = call.AmbulanceBrigade.Driver;
            lableKMBefore.Content = call.KilometrageBefor;
            lableKMAfter.Content = call.KilometrageAfter;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
