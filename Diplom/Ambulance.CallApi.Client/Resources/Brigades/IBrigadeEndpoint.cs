using Ambulance.Domain.Models.Brigade;
using RestEase;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.CallApi.Client.Resources.Brigades
{
    public interface IBrigadeEndpoint : IBaseContract
    {
        [Get("api/brigade")]
        Task<HttpResponseMessage> GetBrigades(CancellationToken cancellationToken = default);

        [Post("api/brigade/create")]
        Task<HttpResponseMessage> CreateBrigade([Body] CreateBrigadeRequest request, CancellationToken cancellationToken = default);

        [Delete("api/brigade/remove")]
        Task<HttpResponseMessage> RemoveBrigade([Body] int brigadeId, CancellationToken cancellationToken = default);

        [Patch("api/brigade/assignCall")]
        Task<HttpResponseMessage> AssignCallToBrigade([Body] AssignCallRequest request, CancellationToken cancellationToken = default);

        [Patch("api/brigade/release")]
        Task<HttpResponseMessage> ReleaseBrigade([Body] int brigadeId, CancellationToken cancellationToken = default);

        [Patch("api/brigade/return")]
        Task<HttpResponseMessage> ReturnCall([Body] int brigadeId, CancellationToken cancellationToken = default);
    }
}
