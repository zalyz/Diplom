using Ambulance.Domain.Models.Account;
using Ambulance.IdentityApi.Client.Resources;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.IdentityApiClient.Resources.Account
{
    public class AccountResource : ResourceBase<IAccountEndpoint>, IAccountResource
    {
        public AccountResource(IAccountEndpoint apiClient, string tenant)
            : base(apiClient, tenant)
        {
        }

        public Task<string> Login(LoginModel model, CancellationToken cancellationToken = default)
        {
            return Execute<string>(token => Client.Login(model, token), cancellationToken);
        }

        public async Task Register(RegisterModel model, CancellationToken cancellationToken = default)
        {
            await Execute(token => Client.Register(model, token), cancellationToken);
        }

        public Task<bool> ValidateToken(string token, CancellationToken cancellationToken = default)
        {
            return Execute<bool>(cToken => Client.ValidateToken(token, cToken), cancellationToken);
        }
    }
}
