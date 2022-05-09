using Ambulance.ServiceAPI.Client.Resources.Dispatcher;
using Ambulance.ServiceAPI.Client.Resources.Doktors;
using Ambulance.ServiceAPI.Client.Resources.Service;

namespace Ambulance.ServiceAPI.Client
{
    public interface IServiceApiClient
    {
        IServiceResource ServiceResource { get; }

        IDispatcherResource DispatcherResource { get; }

        IEmployeeResource EmployeeResource { get; }
    }

    public class ServiceApiClient : IServiceApiClient
    {
        private readonly ResourceCreator _resourceCreator;

        public ServiceApiClient(string baseAddress, string tenant)
        {
            _resourceCreator = new ResourceCreator(baseAddress, tenant);
        }

        public IServiceResource ServiceResource => _resourceCreator.CreateResource<IServiceEndpoint, ServiceResource>();

        public IDispatcherResource DispatcherResource => _resourceCreator.CreateResource<IDispatcherEndpoint, DispatcherResource>();

        public IEmployeeResource EmployeeResource => _resourceCreator.CreateResource<IEmployeeEndpoint, EmployeeResource>();
    }
}
