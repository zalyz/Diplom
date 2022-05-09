using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.DAL.CallAPI.Models
{
    [Table("Streets")]
    public class StreetEntity
    {
        public int Id { get; set; }

        [MaxLength(500, ErrorMessage = "Street more then 500 characters.")]
        public string Name { get; set; }
    }
}
