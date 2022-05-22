using Ambulance.Domain.Models.Account;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.IdentityApi.Client.Resources.Account
{
    public interface IAccountResource
    {
        Task Register(RegisterModel model, CancellationToken cancellationToken = default);

        Task<string> Login(LoginModel model, CancellationToken cancellationToken = default);

        Task<bool> ValidateToken(string token, CancellationToken cancellationToken = default);
    }
}
