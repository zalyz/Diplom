using Ambulance.Domain.Models.Account;
using Ambulance.IdentityApi.Client;
using Ambulance.Web.Constants;
using Blazored.LocalStorage;
using System.Threading.Tasks;

namespace Ambulance.Web.Authorization
{
    public interface IAuthorizationService
    {
        Task LogIn(string login, string password);

        void LogOut();
    }

    public class AuthorizationService : IAuthorizationService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IIdentityApiClient _identityApiClient;
        private readonly IJwtAuthenticationStateProvider _stateProvider;

        public AuthorizationService(
            ILocalStorageService localStorage,
            IIdentityApiClient identityApiClient,
            IJwtAuthenticationStateProvider stateProvider)
        {
            _localStorage = localStorage;
            _identityApiClient = identityApiClient;
            _stateProvider = stateProvider;
        }

        public async Task LogIn(string login, string password)
        {
            var token = await _identityApiClient.AccountResource.Login(new LoginModel
            {
                Login = login,
                Password = password,
            });

            await _localStorage.SetItemAsStringAsync(AuthorizationConstants.LocalStorageTokenName, token);
            _stateProvider.AuthorizationStatusChanged();
        }

        public async void LogOut()
        {
            await _localStorage.RemoveItemAsync(AuthorizationConstants.LocalStorageTokenName);
        }
    }
}
