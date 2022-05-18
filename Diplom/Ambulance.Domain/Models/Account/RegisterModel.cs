using System.ComponentModel.DataAnnotations;

namespace Ambulance.Domain.Models.Account
{
    public class RegisterModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public int? MedicalAssistantId { get; set; }
    }
}
