using Ambulance.Domain.Models.Account;
using Ambulance.IdentityApi.Client.Resources;
using RestEase;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.IdentityApi.Client.Resources.Account
{
    public interface IAccountEndpoint : IBaseContract
    {
        [Post("api/account/register")]
        Task<HttpResponseMessage> Register([Body] RegisterModel model, CancellationToken cancellationToken = default);

        [Post("api/account/login")]
        Task<HttpResponseMessage> Login([Body] LoginModel model, CancellationToken cancellationToken = default);

        [Get("api/account/validate")]
        Task<HttpResponseMessage> ValidateToken([Query] string token, CancellationToken cancellationToken = default);
    }
}
