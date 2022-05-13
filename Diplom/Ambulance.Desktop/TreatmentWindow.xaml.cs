using Ambulance.Domain.Models;
using Ambulance.ServiceAPI.Client;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for TreatmentWindow.xaml
    /// </summary>
    public partial class TreatmentWindow : Window
    {
        public ObservableCollection<Drug> Treatment { get; set; } = new();

        private readonly List<Drug> _drugs = new List<Drug>();

        public TreatmentWindow(IServiceApiClient serviceApiClient)
        {
            InitializeComponent();
            _drugs = serviceApiClient.ServiceResource.GetDrugs().GetAwaiter().GetResult();
            comboTreatment.ItemsSource = _drugs;
            DataContext = Treatment;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Treatment.Clear();
            textTreatment.Text = "";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var id = (int)comboTreatment.SelectedValue;
            Treatment.Add(_drugs.First(e => e.Id == id));
            textTreatment.Text = string.Join("\n", Treatment.Select(e => e.Info));
        }
    }
}
