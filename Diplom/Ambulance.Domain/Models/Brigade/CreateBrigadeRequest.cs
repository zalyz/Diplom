using Ambulance.Domain.Models.Enums;
using System;

namespace Ambulance.Domain.Models.Brigade
{
    public class CreateBrigadeRequest
    {
        public int DoktorId { get; set; }

        public int FirstMedicalAssistantId { get; set; }

        public int? SecondMedicalAssistantId { get; set; }

        public int DriverId { get; set; }

        public int OrderlyId { get; set; }

        public int Number { get; set; }

        public BrigadeType BrigadeType { get; set; }

        public DateTime DateTimeStart { get; set; }

        public string StationName { get; set; }
    }
}
