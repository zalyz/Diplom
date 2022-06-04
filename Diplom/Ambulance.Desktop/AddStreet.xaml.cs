using Ambulance.Domain.Models.ServiceModels;
using Ambulance.ServiceAPI.Client;
using System.Collections.ObjectModel;
using System.Windows;

namespace Ambulance.Desktop
{
    /// <summary>
    /// Interaction logic for AddStreet.xaml
    /// </summary>
    public partial class AddStreet : Window
    {
        private readonly IServiceApiClient _serviceApiClient;

        public ObservableCollection<string> DiagnosisList { get; } =  new ObservableCollection<string>();

        public AddStreet(IServiceApiClient serviceApiClient)
        {
            _serviceApiClient = serviceApiClient;
            InitializeComponent();
            Update();
        }

        private async void Update()
        {
            ListDiagnoses.ItemsSource = null;
            DiagnosisList.Clear();
            var diag = await _serviceApiClient.ServiceResource.GetStreets();
            diag.ForEach(e =>  DiagnosisList.Add(e.Name));
            ListDiagnoses.ItemsSource = DiagnosisList;
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

                Update();

                text1.Text = "";
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
