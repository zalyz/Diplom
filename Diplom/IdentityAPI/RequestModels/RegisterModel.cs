using System.ComponentModel.DataAnnotations;

namespace IdentityAPI.RequestModels
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string TimeZone { get; set; }

        [Required]
        public string Language { get; set; }
    }
}
