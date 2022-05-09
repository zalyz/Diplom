using RestEase;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.ServiceAPI.Client.Resources.Dispatcher
{
    public interface IDispatcherEndpoint : IBaseContract
    {
        [Get("api/dispatcher")]
        Task<HttpResponseMessage> GetDispatcher([Body] int dispatcherId, CancellationToken cancellationToken = default);
    }
}
