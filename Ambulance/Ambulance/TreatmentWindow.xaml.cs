using System.Text;
using System.Windows;
using Ambulance.Classes;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for TreatmentWindow.xaml
    /// </summary>
    public partial class TreatmentWindow : Window
    {
        private string _treatment;

        private StringBuilder stringBuilder = new StringBuilder();

        public TreatmentWindow()
        {
            InitializeComponent();
            comboTreatment.ItemsSource = ServerService.GetTreatment();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            textTreatment.Text = "";
            stringBuilder.Clear();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            stringBuilder.Append(comboTreatment.Text + "\n");
            _treatment = stringBuilder.ToString();
            textTreatment.Text = stringBuilder.ToString();
        }
    }
}
