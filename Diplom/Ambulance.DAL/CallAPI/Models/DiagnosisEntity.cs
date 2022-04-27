using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.DAL.CallAPI.Models
{
    [Table("Diagnosies")]
    public class DiagnosisEntity
    {
        public int Id { get; set; }

        [MaxLength(500, ErrorMessage = "Diagnosis name is more then 500 characters.")]
        public string Name { get; set; }

        [MaxLength(5, ErrorMessage = "Diagnosis number is more then 100 characters.")]
        public string Number { get; set; }
    }
}
