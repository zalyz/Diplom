using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.DAL.CallAPI.Models
{
    [Table("Medicaments")]
    public class MedicamentEntity
    {
        public int Id { get; set; }

        public int TreatmentId { get; set; }

        public int DrugId { get; set; }
    }
}
