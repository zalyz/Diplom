using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.DAL.CallAPI.Models
{
    [Table("Places")]
    public class PlaceEntity
    {
        public int Id { get; set; }

        [MaxLength(300, ErrorMessage = "Place name is more then 300 characters.")]
        public string Name { get; set; }
    }
}
