using Ambulance.Web.Authorization;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Ambulance.Web.Pages
{
    public partial class Login
    {
        [Inject]
        private IAuthorizationService AuthorizationService { get; set; }

        private async Task LogIn()
        {
            await AuthorizationService.LogIn("testLogin", "07072000");
        }
    }
}