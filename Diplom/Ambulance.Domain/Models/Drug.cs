namespace Ambulance.Domain.Models
{
    public class Drug
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Dosage { get; set; }

        public string Info => $"{Name} / {Dosage}";
    }
}
