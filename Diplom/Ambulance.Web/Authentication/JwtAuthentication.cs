using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace Ambulance.Web.Authentication
{
    public class JwtAuthentication : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
        }
    }
}
