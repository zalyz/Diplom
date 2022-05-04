using System.ComponentModel.DataAnnotations;

namespace Ambulance.DAL.CallAPI.Models
{
    public class StreetEntity
    {
        public int Id { get; set; }

        [MaxLength(500, ErrorMessage = "Street more then 500 characters.")]
        public string Name { get; set; }
    }
}
