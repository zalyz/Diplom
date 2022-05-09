using System;
using System.Windows;
using Ambulance.ServiceAPI.Client;
using System.Threading.Tasks;
using Ambulance.Domain.Models;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for DispatcherRegistrationWindow.xaml
    /// </summary>
    public partial class DispatcherRegistrationWindow : Window
    {
        private readonly IServiceApiClient _serviceClient;

        public Dispatcher Dispatcher;

        public DispatcherRegistrationWindow(IServiceApiClient serviceClient)
        {
            _serviceClient = serviceClient;
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Dispatcher != null)
                {
                    Owner.Title = "Скорая помощь " + $"[{Dispatcher.Surname} {Dispatcher.Name[0]}.{Dispatcher.MiddleName[0]}]";
                    Close();
                }
                else
                {
                    throw new ArgumentException("Не верно введен диспетчер");
                }

            }
            catch (ArgumentException argException)
            {
                MessageBox.Show(argException.Message);
            }
        }

        private async void DispatcherNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var dispatcherNumber = int.Parse(textDispatcherNumber.Text);
                var dispatcher = await _serviceClient.DispatcherResource.GetDispatcher(dispatcherNumber);
                if (dispatcher != null)
                {
                    textDispatcherFIO.Text = $"{dispatcher.Surname} {dispatcher.Name[0]}.{dispatcher.MiddleName[0]}";
                    Dispatcher = dispatcher;
                }
            }
            catch (ArgumentException argException)
            {
                MessageBox.Show(argException.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
