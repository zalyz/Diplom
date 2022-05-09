using RestEase;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.ServiceAPI.Client.Resources.Service
{
    public interface IServiceEndpoint : IBaseContract
    {
        [Get("api/service/callers")]
        Task<HttpResponseMessage> GetCallers(CancellationToken cancellationToken = default);

        [Get("api/service/diagnosis")]
        Task<HttpResponseMessage> GetDiagnosis(CancellationToken cancellationToken = default);

        [Get("api/service/streets")]
        Task<HttpResponseMessage> GetStreets(CancellationToken cancellationToken = default);

        [Get("api/service/places")]
        Task<HttpResponseMessage> GetPlaces(CancellationToken cancellationToken = default);

        [Get("api/service/results")]
        Task<HttpResponseMessage> GetResults(CancellationToken cancellationToken = default);
    }
}
