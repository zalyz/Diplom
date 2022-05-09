using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.ServiceAPI.Client.Resources.Dispatcher
{
    public class DispatcherResource : ResourceBase<IDispatcherEndpoint>, IDispatcherResource
    {
        public DispatcherResource(IDispatcherEndpoint apiClient, string tenant)
            : base(apiClient, tenant)
        {
        }

        public Task<Domain.Models.Dispatcher> GetDispatcher(int dispatcherId, CancellationToken cancellationToken = default)
        {
            return Execute<Domain.Models.Dispatcher>(token => Client.GetDispatcher(dispatcherId, token), cancellationToken);
        }
    }
}
