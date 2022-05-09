using Ambulance.Domain.Models.Enums;
using System;

namespace Ambulance.Domain.Models
{
    public class BrigadeMonitoringInfo
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public BrigadeType BrigadeType { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public int CallId { get; set; }

        public int? CallNumber { get; set; }

        public DateTime ActionDateTime { get; set; }

        public string StationName { get; set; }
    }
}
