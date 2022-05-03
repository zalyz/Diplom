using Ambulance.Domain.Models.Enums;

namespace Ambulance.Domain.Models
{
    public class AmbulanceBrigade
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public BrigadeType BrigadeType { get; set; }

        public int CallId { get; set; }

        public string StationName { get; set; }
    }
}
