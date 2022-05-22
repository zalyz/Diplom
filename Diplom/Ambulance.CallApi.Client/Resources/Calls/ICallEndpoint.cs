using Ambulance.Domain.Models.Call;
using RestEase;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.CallApi.Client.Resources.Calls
{
    [AllowAnyStatusCode]
    public interface ICallEndpoint : IBaseContract
    {
        [Get("api/call")]
        Task<HttpResponseMessage> GetCall([Body] int id, CancellationToken cancellationToken = default);

        [Get("api/call/accepted")]
        Task<HttpResponseMessage> GetAccepted(CancellationToken cancellationToken = default);

        [Get("api/call/pending")]
        Task<HttpResponseMessage> GetPending(CancellationToken cancellationToken = default);

        [Post("api/call/create")]
        Task<HttpResponseMessage> CreateCall([Body]CreateCallRequest request, CancellationToken cancellationToken = default);

        [Patch("api/call/process")]
        Task<HttpResponseMessage> ProcessCall([Body] ProcessCallRequest request, CancellationToken cancellationToken = default);

        [Post("api/call/filter")]
        Task<HttpResponseMessage> FilterCall([Body] FilterRequest request, CancellationToken cancellationToken = default);

        [Post("api/call/additional")]
        Task<HttpResponseMessage> AddAdditionalInfo([Body] AdditionalInfoRequest request, CancellationToken cancellationToken = default);
    }
}
