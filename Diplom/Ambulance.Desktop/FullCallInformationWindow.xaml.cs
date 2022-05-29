using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Ambulance.Domain.Models;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for FullCallInformationWindow.xaml
    /// </summary>
    public partial class FullCallInformationWindow : Window
    {
        public FullCallInformationWindow(CallFullOfficeInfo call, List<Treatment> treatments)
        {
            InitializeComponent();
            lableFIO.Content = call.FIO;
            lableAge.Content = call.Age;
            lableStreet.Content = call.Street;
            lableHouseNumber.Content = call.HouseNumber;
            lableFlatNumber.Content = call.FlatNumber;
            lableGender.Content = call.Gender;

            lableDiagnosis.Content = call.DiagnosisName;
            lableResult.Content = call.ResultName;
            textTreatment.Text = string.Join("\n", treatments);
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

            lablUrgency.Content = call.Type;
            lableDispatcherTransfered.Content = call.TransferingDispatcher;
            lableDispatcherProcessed.Content = call.ProcessingDispatcher;
            lableBrigadeNumber.Content = call.BrigadeNumber;
            lableDoktor.Content = call.DoktorFIO;
            lableMedAssistant1.Content = call.FirstMedicalAssistantFIO;
            lableMedAssistant2.Content = call.SecondMedicalAssistantFIO;
            lableOrderly.Content = call.OrderlyFIO;
            lableDriver.Content = call.DriverFIO;
            lableKMBefore.Content = call.KilometrageBefor;
            lableKMAfter.Content = call.KilometrageAfter;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
