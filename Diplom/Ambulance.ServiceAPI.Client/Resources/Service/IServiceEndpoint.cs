using Ambulance.Domain.Models.ServiceModels;
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

        [Post("api/service/diagnosis")]
        Task<HttpResponseMessage> AddDiagnosis([Body] AddDiagnosisRequest request, CancellationToken cancellationToken = default);

        [Get("api/service/streets")]
        Task<HttpResponseMessage> GetStreets(CancellationToken cancellationToken = default);

        [Post("api/service/streets")]
        Task<HttpResponseMessage> AddStreet([Body] AddStreetRequest request, CancellationToken cancellationToken = default);

        [Get("api/service/places")]
        Task<HttpResponseMessage> GetPlaces(CancellationToken cancellationToken = default);

        [Get("api/service/results")]
        Task<HttpResponseMessage> GetResults(CancellationToken cancellationToken = default);

        [Get("api/service/drugs")]
        Task<HttpResponseMessage> GetDrugs(CancellationToken cancellationToken = default);
    }
}
