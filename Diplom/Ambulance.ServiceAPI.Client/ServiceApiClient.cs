using Ambulance.ServiceAPI.Client.Resources.Service;

namespace Ambulance.ServiceAPI.Client
{
    public interface IServiceApiClient
    {
        IServiceResource ServiceResource { get; }
    }

    public class ServiceApiClient : IServiceApiClient
    {
        private readonly ResourceCreator _resourceCreator;

        public ServiceApiClient(string baseAddress, string tenant)
        {
            _resourceCreator = new ResourceCreator(baseAddress, tenant);
        }

        public IServiceResource ServiceResource => _resourceCreator.CreateResource<IServiceEndpoint, ServiceResource>();
    }
}
