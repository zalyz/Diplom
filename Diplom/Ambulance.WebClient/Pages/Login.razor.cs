using Ambulance.WebClient.Authorization;
using Microsoft.AspNetCore.Components;

namespace Ambulance.WebClient.Pages
{
    public partial class Login
    {
        [Inject]
        private IAuthorizationService AuthorizationService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        public LoginModel model = new();

        private async Task LogIn()
        {
            await AuthorizationService.LogIn(model.Login, model.Password);
            NavigationManager.NavigateTo("", true);
            model = new();
        }

        public class LoginModel
        {
            public string Login { get; set; }

            public string Password { get; set; }
        }
    }
}