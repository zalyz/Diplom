using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.ServiceAPI.Client.Resources.Dispatcher
{
    public interface IDispatcherResource
    {
        Task<Domain.Models.Dispatcher> GetDispatcher(int dispatcherId, CancellationToken cancellationToken = default);
    }
}
