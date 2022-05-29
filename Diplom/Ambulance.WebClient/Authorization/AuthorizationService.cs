using Ambulance.Domain.Models.Account;
using Ambulance.IdentityApi.Client;
using Ambulance.WebClient.Constants;
using Blazored.LocalStorage;
using System.ComponentModel.DataAnnotations;

namespace Ambulance.WebClient.Authorization
{
    public interface IAuthorizationService
    {
        Task LogIn(string login, string password);

        Task LogOut();

        Task Register(RegisterUserModel model);
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

        public async Task LogOut()
        {
            await _localStorage.RemoveItemAsync(AuthorizationConstants.LocalStorageTokenName);
        }

        public async Task Register(RegisterUserModel model)
        {
            await _identityApiClient.AccountResource.Register(new RegisterModel
            {
                Email = model.Email,
                Login = model.Login,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
            });
        }
    }

    public class RegisterUserModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Login { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
