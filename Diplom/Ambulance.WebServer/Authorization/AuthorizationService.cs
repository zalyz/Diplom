using Ambulance.Domain.Models.Account;
using Ambulance.IdentityApi.Client;
using Blazored.LocalStorage;
using System.Threading.Tasks;

namespace Ambulance.WebServer.Authorization
{
    public interface IAuthorizationService
    {
        Task LogIn(string login, string password);

        void LogOut();
    }

    public class AuthorizationService : IAuthorizationService
    {
        private const string ItemName = "JwtToken";

        private readonly ILocalStorageService _localStorage;
        private readonly IIdentityApiClient _identityApiClient;

        public AuthorizationService(ILocalStorageService localStorage, IIdentityApiClient identityApiClient)
        {
            _localStorage = localStorage;
            _identityApiClient = identityApiClient;
        }

        public async Task LogIn(string login, string password)
        {
            var token = await _identityApiClient.AccountResource.Login(new LoginModel
            {
                Login = login,
                Password = password,
            });

            await _localStorage.SetItemAsStringAsync(ItemName, token);
        }

        public async void LogOut()
        {
            await _localStorage.RemoveItemAsync(ItemName);
        }
    }
}
