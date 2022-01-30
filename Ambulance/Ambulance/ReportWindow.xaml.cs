using System.Windows;
using System.Linq;
using Ambulance.Classes;
using Ambulance.DBAccess;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private AmbulanceDBContext _context = new AmbulanceDBContext();

        public ReportWindow()
        {
            InitializeComponent();
            comboDiagnosis.ItemsSource = ServerService.GetDiagnoses();
            comboResult.ItemsSource = ServerService.GetResults();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var count1 = _context.ProcessedCalls.Count();
            count1 = _context.IncidentalCalls.Count();
            lable1.Content = count1.ToString();
            var count2 = _context.Patients.Count();
            lable2.Content = count2.ToString();
            var count3 = _context.ChronicPatients.Count();
            lable3.Content = count3.ToString();
            var count4 = _context.ProcessedCalls.Where(e => e.Results == "Безрезультатный").Count();
            count4 = _context.IncidentalCalls.Where(e => e.Results == "Безрезультатный").Count();
            lable4.Content = count4.ToString();
            var count5 = _context.ProcessedCalls.Where(e => e.Results.Contains("Смерть")).Count();
            count5 += _context.IncidentalCalls.Where(e => e.Results.Contains("Смерть")).Count();
            lable5.Content = count5.ToString();
            var count6 = _context.ProcessedCalls.Where(e => e.Results == "Отказ от госпитализации").Count();
            count6 = _context.IncidentalCalls.Where(e => e.Results == "Отказ от госпитализации").Count();
            lable6.Content = count6.ToString();
            var count7 = _context.Doktors.Count();
            count7 = _context.MedicalAssistants.Count();
            count7 = _context.Orderlies.Count();
            count7 = _context.Drivers.Count();
            count7 = _context.Dispatchers.Count();
            lable7.Content = count7.ToString();
            var count8 = _context.Patients.Where(e => e.Gender.Contains("МУЖ")).Count();
            lable8.Content = count8.ToString();
            var count9 = _context.Patients.Where(e => e.Gender.Contains("ЖЕН")).Count();
            lable9.Content = count9.ToString();
            var count10 = _context.IncidentalCalls.Count();
            lable10.Content = count10.ToString();
            var count11 = _context.Patients.Where(e => e.Age < 18).Count();
            lable11.Content = count11.ToString();
            var count12 = _context.ProcessedCalls.Where(e => e.CallType == "Экстренный").Count();
            lable12.Content = count12.ToString();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DiagnosisButton_Click(object sender, RoutedEventArgs e)
        {
            var diagnosis = comboDiagnosis.Text;
            lableDiagnosis.Content = _context.ProcessedCalls.Where(e => e.Diagnosis == diagnosis).Count();
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            var result = comboResult.Text;
            lableResult.Content = _context.ProcessedCalls.Where(e => e.Results == result).Count();
        }
    }
}
