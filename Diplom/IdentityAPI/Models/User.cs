using IdentityAPI.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace IdentityAPI.Models
{
    public class User : IdentityUser
    {
        public string TimeZone { get; set; }

        public UserLanguage Language { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }
    }
}
