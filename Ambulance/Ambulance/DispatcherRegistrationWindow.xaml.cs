using System;
using System.Windows;
using System.Linq;
using Ambulance.DBAccess;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for DispatcherRegistrationWindow.xaml
    /// </summary>
    public partial class DispatcherRegistrationWindow : Window
    {
        public string AmbDispatcher;

        private AmbulanceDBContext _context;

        public DispatcherRegistrationWindow()
        {
            InitializeComponent();
            _context = new AmbulanceDBContext();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AmbDispatcher != null)
                {
                    this.Owner.Title = "Скорая помощь " + $"[{AmbDispatcher}]";
                    this.Close();
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

        private void DispatcherNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var dispatcherNumber = int.Parse(textDispatcherNumber.Text);
                var dispatcher = _context.Dispatchers.Where(e => e.Id == dispatcherNumber).FirstOrDefault();
                if (dispatcher != null)
                {
                    textDispatcherFIO.Text = dispatcher.ToString();
                    AmbDispatcher = dispatcher.ToString();
                }
            }
            catch (ArgumentException argException)
            {
                MessageBox.Show(argException.Message);
            }
            catch (FormatException formatException)
            {
                ;
            }
        }
    }
}
