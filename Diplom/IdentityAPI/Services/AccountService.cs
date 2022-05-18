using Ambulance.DAL.CallAPI;
using Ambulance.DAL.CallAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using Ambulance.Domain.Models.Account;

namespace IdentityAPI.Services
{
    public interface IAccountService
    {
        Task<bool> Register(RegisterModel model);

        Task<string> Login(LoginModel model);
    }

    public class AccountService : IAccountService
    {
        private readonly IDatabaseProvider _databaseProvider;
        private readonly ITokenService _tokenService;

        public AccountService(IDatabaseProvider databaseProvider, ITokenService tokenService)
        {
            _databaseProvider = databaseProvider;
            _tokenService = tokenService;
        }

        public async Task<string> Login(LoginModel model)
        {
            var user = await _databaseProvider.InDatabaseScope(context => context.Users.FirstAsync(e => e.Login == model.Login));
            if (!IsPasswordCorrect(model.Password, user.PasswordHash))
            {
                return string.Empty;
            }

            var roles = await _databaseProvider.InDatabaseScope(context =>
            {
                return from user in context.Users
                       join ur in context.UserRoles on user.Id equals ur.UserId
                       join role in context.Roles on ur.RoleId equals role.Id
                       select role;
            });

            var roleNames = await roles.Select(e => e.Name).ToListAsync();

            return _tokenService.GetToken(user, roleNames);
        }

        public void PasswordValidation()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Register(RegisterModel model)
        {
            if (!string.Equals(model.Password, model.ConfirmPassword))
            {
                return false;
            }

            var passwordHash = GetPasswordHash(model.Password);
            var user = new UserEntity
            {
                Login = model.Login,
                Email = model.Email,
                PasswordHash = passwordHash,
                MedicalAssistantId = model.MedicalAssistantId,
            };

            await AddWithDefaultRole(user);
            return true;
        }

        private string GetPasswordHash(string password)
        {
            var hasher = new PasswordHasher<object>();
            return hasher.HashPassword(null, password);
        }

        private bool IsPasswordCorrect(string password, string hash)
        {
            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, hash, password);
            return result switch
            {
                PasswordVerificationResult.Success => true,
                PasswordVerificationResult.Failed => false,
                _ => false,
            };
        }

        private async Task AddWithDefaultRole(UserEntity userEntity)
        {
            await _databaseProvider.InDatabaseScope(context => context.Users.AddAsync(userEntity));
            await _databaseProvider.InDatabaseScope(context => context.UserRoles.AddAsync(new UserRoleEntity
            {
                UserId = userEntity.Id,
                RoleId = 1,
            }));
        }
    }
}
