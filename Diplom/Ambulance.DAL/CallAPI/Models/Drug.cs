using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.DAL.CallAPI.Models
{
    [Table("Drugs")]
    public class Drug
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Dosage { get; set; }
    }
}
