using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.DAL.CallAPI.Models
{
    [Table("Drugs")]
    public class DrugEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Dosage { get; set; }
    }
}
