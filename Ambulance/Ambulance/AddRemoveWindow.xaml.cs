using System.Windows;
using Ambulance.Classes;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for AddDiagnosis.xaml
    /// </summary>
    public partial class AddDiagnosis : Window
    {
        private bool _isDiagnosis;

        public AddDiagnosis(bool isDiagnsis)
        {
            InitializeComponent();
            _isDiagnosis = isDiagnsis;
            if (isDiagnsis)
            {
                Lable.Content = "Добавление/Удаление диагноза";
                ListDiagnoses.ItemsSource = ServerService.GetDiagnoses();
            }
            else
            {
                Lable.Content = "Добавление/Удаление улицы";
                ListDiagnoses.ItemsSource = ServerService.GetStreets();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var text = text1.Text;
            if (!string.IsNullOrEmpty(text))
            {
                if (_isDiagnosis)
                {
                    ServerService.AddDiagnosis(text);
                    ListDiagnoses.ItemsSource = null;
                    ListDiagnoses.ItemsSource = ServerService.GetDiagnoses();
                }
                else
                {
                    ServerService.AddStreet(text);
                    ListDiagnoses.ItemsSource = null;
                    ListDiagnoses.ItemsSource = ServerService.GetStreets();
                }

                text1.Text = "";
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_isDiagnosis)
                {
                    var text = ServerService.GetDiagnoses()[ListDiagnoses.SelectedIndex];
                    if (!string.IsNullOrEmpty(text))
                    {
                        ServerService.RemoveDiagnosis(text);
                        ListDiagnoses.ItemsSource = null;
                        ListDiagnoses.ItemsSource = ServerService.GetDiagnoses();
                    }
                }
                else
                {

                    var text = ServerService.GetStreets()[ListDiagnoses.SelectedIndex];
                    if (!string.IsNullOrEmpty(text))
                    {
                        ServerService.RemoveStreet(text);
                        ListDiagnoses.ItemsSource = null;
                        ListDiagnoses.ItemsSource = ServerService.GetStreets();
                    }
                }
            }
            catch
            {

            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
