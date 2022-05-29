using Microsoft.AspNetCore.Components;
using Ambulance.WebClient.Authorization;

namespace Ambulance.WebClient.Pages
{
    public partial class Register
    {
        private RegisterUserModel model = new ();

        [Inject]
        private IAuthorizationService AuthorizationService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private async Task OnValidSubmit()
        {
            await AuthorizationService.Register(model);
            NavigationManager.NavigateTo("login");
        }
    }
}