using Ambulance.Domain.Models.ServiceModels;
using Ambulance.ServiceAPI.Client;
using System.Windows;

namespace Ambulance.Desktop
{
    /// <summary>
    /// Interaction logic for AddStreet.xaml
    /// </summary>
    public partial class AddStreet : Window
    {
        private readonly IServiceApiClient _serviceApiClient;

        public AddStreet(IServiceApiClient serviceApiClient)
        {
            _serviceApiClient = serviceApiClient;
            InitializeComponent();
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var text = text1.Text;
            if (!string.IsNullOrEmpty(text))
            {
                await _serviceApiClient.ServiceResource.AddStreet(new AddStreetRequest
                {
                    Name = text,
                });
                ListDiagnoses.ItemsSource = null;
                ListDiagnoses.ItemsSource = await _serviceApiClient.ServiceResource.GetDiagnosis();

                text1.Text = "";
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
