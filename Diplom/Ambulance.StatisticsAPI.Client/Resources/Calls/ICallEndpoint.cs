using RestEase;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.StatisticsApi.Client.Resources.Calls
{
    public interface ICallEndpoint : IBaseContract
    {
        [Get("api/call/diagnosisGender")]
        Task<HttpResponseMessage> GetDiagnosisGenderCalls(CancellationToken cancellationToken = default);

        [Get("api/call/calls")]
        Task<HttpResponseMessage> GetCalls(CancellationToken cancellationToken = default);

        [Get("api/call/ageDiagnosis")]
        Task<HttpResponseMessage> GetAgeDiagnosis(CancellationToken cancellationToken = default);
    }
}
