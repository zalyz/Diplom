using Ambulance.Domain.Models.ServiceModels;
using Ambulance.ServiceAPI.Client;
using System.Windows;

namespace Ambulance.Desktop
{
    /// <summary>
    /// Interaction logic for AddDiagnosis.xaml
    /// </summary>
    public partial class AddDiagnosis : Window
    {
        private readonly IServiceApiClient _serviceApiClient;

        public AddDiagnosis(IServiceApiClient serviceApiClient)
        {
            _serviceApiClient = serviceApiClient;
            InitializeComponent();
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
                ListDiagnoses.ItemsSource = null;
                ListDiagnoses.ItemsSource = await _serviceApiClient.ServiceResource.GetDiagnosis();

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
