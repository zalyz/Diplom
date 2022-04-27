using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.DAL.CallAPI.Models
{
    [Table("Treatments")]
    public class TreatmentEntity
    {
        public int Id { get; set; }

        public int CallId { get; set; }
    }
}
