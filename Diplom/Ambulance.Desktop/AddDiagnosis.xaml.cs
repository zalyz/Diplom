using Ambulance.Domain.Models.ServiceModels;
using Ambulance.ServiceAPI.Client;
using System.Collections.ObjectModel;
using System.Windows;

namespace Ambulance.Desktop
{
    /// <summary>
    /// Interaction logic for AddDiagnosis.xaml
    /// </summary>
    public partial class AddDiagnosis : Window
    {
        private readonly IServiceApiClient _serviceApiClient;

        public ObservableCollection<string> DiagnosisList { get; } = new ObservableCollection<string>();

        public AddDiagnosis(IServiceApiClient serviceApiClient)
        {
            _serviceApiClient = serviceApiClient;
            InitializeComponent();
            Update();
        }

        private async void Update()
        {
            ListDiagnoses.ItemsSource = null;
            DiagnosisList.Clear();
            var diag = await _serviceApiClient.ServiceResource.GetDiagnosis();
            diag.ForEach(e => DiagnosisList.Add(e.Name + " " + e.Number));
            ListDiagnoses.ItemsSource = DiagnosisList;
        }
        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var text = text1.Text;
            var number = textNumber.Text;
            if (!string.IsNullOrEmpty(text))
            {
                await _serviceApiClient.ServiceResource.AddDiagnosis(new AddDiagnosisRequest
                {
                    Name = text,
                    Number = number,
                });

                text1.Text = "";
                textNumber.Text = "";
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
