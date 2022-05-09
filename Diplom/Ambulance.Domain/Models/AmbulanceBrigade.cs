using Ambulance.Domain.Models.Enums;

namespace Ambulance.Domain.Models
{
    public class AmbulanceBrigade
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string DoctorFIO { get; set; }

        public string FirstMedicalAssistantFIO { get; set; }

        public string SecondMedicalAssistantFIO { get; set; }

        public string OrderlyFIO { get; set; }

        public string DriverFIO { get; set; }

        public BrigadeType BrigadeType { get; set; }

        public string StationName { get; set; }
    }
}
