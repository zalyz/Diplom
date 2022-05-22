using Ambulance.Domain.Models.Enums;
using System;

namespace Ambulance.Domain.Models.Call
{
    public class FilterRequest
    {
        public int? CallNumber { get; set; }

        public string FIO { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string FlatNumber { get; set; }

        public string Diagnosis { get; set; }

        public string Result { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public int? NumberOfElementsOnPage { get; set; } = 1;

        public int? PageNumber { get; set; } = 1;

        public CallStatus CallStatus { get; set; } = CallStatus.Processed;
    }
}
