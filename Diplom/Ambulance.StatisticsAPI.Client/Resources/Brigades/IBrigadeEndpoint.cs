using RestEase;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.StatisticsApi.Client.Resources.Brigades
{
    public interface IBrigadeEndpoint : IBaseContract
    {
        [Get("api/brigade/brigadeCalls")]
        Task<HttpResponseMessage> GetBrigadeCalls(CancellationToken cancellationToken = default);
    }
}
