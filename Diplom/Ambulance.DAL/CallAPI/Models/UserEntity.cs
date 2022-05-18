using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.DAL.CallAPI.Models
{
    [Table("Users")]
    public class UserEntity
    {
        public int Id { get; set; }

        public int? MedicalAssistantId { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}
