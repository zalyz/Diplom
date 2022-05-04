using RestEase;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.ServiceAPI.Client.Resources.Service
{
    public interface IServiceEndpoint : IBaseContract
    {
        [Get("api/service/callers")]
        public Task<HttpResponseMessage> GetCallers(CancellationToken cancellationToken = default);

        [Get("api/service/diagnosis")]
        public Task<HttpResponseMessage> GetDiagnosis(CancellationToken cancellationToken = default);

        [Get("api/service/streets")]
        public Task<HttpResponseMessage> GetStreets(CancellationToken cancellationToken = default);
    }
}
