using System.ComponentModel.DataAnnotations;

namespace Ambulance.DAL.CallAPI.Models
{
    public class EmployeeBase
    {
        public int Id { get; set; }

        [MaxLength(200, ErrorMessage = "Name is more then 200 characters.")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Surname is more then 200 characters.")]
        public string Surname { get; set; }

        [MaxLength(200, ErrorMessage = "MiddleName is more then 200 characters.")]
        public string MiddleName { get; set; }
    }
}
