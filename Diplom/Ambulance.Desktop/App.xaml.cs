using Ambulance.CallApi.Client;
using Ambulance.ServiceAPI.Client;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Windows;

namespace Ambulance.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            var callAddress = ConfigurationManager.AppSettings["CallApiAddress"];
            var serviceAddress = ConfigurationManager.AppSettings["ServiceApiAddress"];
            var tenant = ConfigurationManager.AppSettings["Tenant"];
            services.AddScoped<ICallApiClient>(x => new CallApiClient(callAddress, tenant));
            services.AddScoped<IServiceApiClient>(x => new ServiceApiClient(serviceAddress, tenant));

            services.AddSingleton<MainWindow>();
        }

        private void OnSturtup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
