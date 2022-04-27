using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.DAL.CallAPI.Models
{
    [Table("Results")]
    public class ResultEntity
    {
        public int Id { get; set; }

        [MaxLength(300, ErrorMessage = "Result name is more then 300 characters.")]
        public string Name { get; set; }
    }
}
