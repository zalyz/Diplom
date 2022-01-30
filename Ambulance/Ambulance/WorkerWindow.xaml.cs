using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using Ambulance.Classes.Staff;
using Ambulance.DBAccess;

namespace Ambulance
{
    /// <summary>
    /// Interaction logic for WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {

        private static AmbulanceDBContext context;

        public WorkerWindow()
        {
            InitializeComponent();
            context = new AmbulanceDBContext();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var listOfWorkers = new List<Worker>();
            string fio = "";
            if (checkAllWorkers.IsChecked == true)
            {
                fio = " ";
            }
            else
            {
                fio = textFIO.Text;

            }

            if (!string.IsNullOrEmpty(fio) || checkAllWorkers.IsChecked == true)
            {
                var workers = new List<Worker>();
                workers = context.Doktors.Where(e => (e.Surname + " " + e.Name + " " + e.MiddleName).ToUpper().Contains(fio.ToUpper())).ToList<Worker>();
                if (workers.Any())
                {
                    listOfWorkers.AddRange(workers);
                }

                workers = context.Dispatchers.Where(e => (e.Surname + " " + e.Name + " " + e.MiddleName).ToUpper().Contains(fio.ToUpper())).ToList<Worker>();
                if (workers.Any())
                {
                    listOfWorkers.AddRange(workers);
                }

                workers = context.MedicalAssistants.Where(e => (e.Surname + " " + e.Name + " " + e.MiddleName).ToUpper().Contains(fio.ToUpper())).ToList<Worker>();
                if (workers.Any())
                {
                    listOfWorkers.AddRange(workers);
                }

                workers = context.Orderlies.Where(e => (e.Surname + " " + e.Name + " " + e.MiddleName).ToUpper().Contains(fio.ToUpper())).ToList<Worker>();
                if (workers.Any())
                {
                    listOfWorkers.AddRange(workers);
                }

                workers = context.Drivers.Where(e => (e.Surname + " " + e.Name + " " + e.MiddleName).ToUpper().Contains(fio.ToUpper())).ToList<Worker>();
                if (workers.Any())
                {
                    listOfWorkers.AddRange(workers);
                }

                workers = context.Statisticians.Where(e => (e.Surname + " " + e.Name + " " + e.MiddleName).ToUpper().Contains(fio.ToUpper())).ToList<Worker>();
                if (workers.Any())
                {
                    listOfWorkers.AddRange(workers);
                }

                UpdateWorkerGrid(listOfWorkers);
                ClearFilds();
            }
            else
            {
                MessageBox.Show("Введите Ф.И.О или выберите 'Все работники'","Ошибка!");
            }
        }

        private void UpdateWorkerGrid(List<Worker> listOfWorkers)
        {
            gridWorkers.ItemsSource = null;
            gridWorkers.ItemsSource = listOfWorkers;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedWorker = gridWorkers.SelectedItem;

            if (selectedWorker != null && MessageBox.Show("Удалить эту запись?", "Удаление сотрудника", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (selectedWorker is Doktor)
                {
                    context.Doktors.Remove((Doktor)selectedWorker);
                }

                if (selectedWorker is Dispatcher)
                {
                    context.Dispatchers.Remove((Classes.Staff.Dispatcher)selectedWorker);
                }

                if (selectedWorker is MedicalAssistant)
                {
                    context.MedicalAssistants.Remove((MedicalAssistant)selectedWorker);
                }

                if (selectedWorker is Orderly)
                {
                    context.Orderlies.Remove((Orderly)selectedWorker);
                }

                if (selectedWorker is Driver)
                {
                    context.Drivers.Remove((Driver)selectedWorker);
                }

                if (selectedWorker is Statistician)
                {
                    context.Statisticians.Remove((Statistician)selectedWorker);
                }
            }

            context.SaveChanges();
            MessageBox.Show($"Сотрудник {((Worker)selectedWorker).ToString()} удален");
            Search_Click(null, null);
            ClearFilds();
        }

        private void ClearFilds()
        {
            textFIO.Text = "";
            comboPosition.Text = "";
        }

        private void AddWorker_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isAdd = false;
                var fio = textFIO.Text.Split(" ");
                var position = comboPosition.Text;
                if (string.IsNullOrEmpty(position) || fio.Length != 3)
                {
                    throw new ArgumentException("Не правильно введено имя или должность сотрудника.");
                }

                switch (position)
                {
                    case "Врач":
                        if (!context.Doktors.Where(e => e.Surname == fio[0] && e.Name == fio[1] && e.MiddleName == fio[2]).Any())
                        {
                            var doctor = new Doktor {Surname = fio[0], Name = fio[1], MiddleName = fio[2]};
                            context.Doktors.Add(doctor);
                            isAdd = true;
                        }

                        break;
                    case "Диспетчер":
                        var dispatcher = new Dispatcher { Surname = fio[0], Name = fio[1], MiddleName = fio[2] };
                        if (!context.Dispatchers.Where(e => e.Surname == fio[0] && e.Name == fio[1] && e.MiddleName == fio[2]).Any())
                        {
                            context.Dispatchers.Add(dispatcher);
                            isAdd = true;
                        }

                        break;
                    case "Фельдшер":
                        var assistant = new MedicalAssistant { Surname = fio[0], Name = fio[1], MiddleName = fio[2] };
                        if (!context.MedicalAssistants.Where(e => e.Surname == fio[0] && e.Name == fio[1] && e.MiddleName == fio[2]).Any())
                        {
                            context.MedicalAssistants.Add(assistant);
                            isAdd = true;
                        }

                        break;
                    case "Санитар":
                        var orderly = new Orderly { Surname = fio[0], Name = fio[1], MiddleName = fio[2] };
                        if (!context.Orderlies.Where(e => e.Surname == fio[0] && e.Name == fio[1] && e.MiddleName == fio[2]).Any())
                        {
                            context.Orderlies.Add(orderly);
                            isAdd = true;
                        }

                        break;
                    case "Водитель":
                        var driver = new Driver { Surname = fio[0], Name = fio[1], MiddleName = fio[2] };
                        if (!context.Drivers.Where(e => e.Surname == fio[0] && e.Name == fio[1] && e.MiddleName == fio[2]).Any())
                        {
                            context.Drivers.Add(driver);
                            isAdd = true;
                        }

                        break;
                    case "Статистик":
                        var statistician = new Statistician { Surname = fio[0], Name = fio[1], MiddleName = fio[2] };
                        if (!context.Statisticians.Where(e => e.Surname == fio[0] && e.Name == fio[1] && e.MiddleName == fio[2]).Any())
                        {
                            context.Statisticians.Add(statistician);
                            isAdd = true;
                        }

                        break;
                    default:
                        throw new ArgumentException();
                }

                if (isAdd)
                {
                    context.SaveChanges();
                    ClearFilds();
                    MessageBox.Show("Сотрудник добавлен.");
                }
                else
                {
                    MessageBox.Show($"Сотрудник {fio[0] + " " + fio[1] + " " + fio[2]} уже добавлен.");
                }
            }
            catch(ArgumentException argException)
            {
                MessageBox.Show(argException.Message);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            context.Dispose();
        }

        private void CheckAllWorkers_Click(object sender, RoutedEventArgs e)
        {
            if (checkAllWorkers.IsChecked == true)
            {
                textFIO.IsEnabled = false;
                comboPosition.IsEnabled = false;
            }
            else
            {
                textFIO.IsEnabled = true;
                comboPosition.IsEnabled = true;
            }
        }
    }
}
