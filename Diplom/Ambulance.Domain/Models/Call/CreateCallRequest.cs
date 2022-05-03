using Ambulance.Domain.Models.Enums;
using System;

namespace Ambulance.Domain.Models.Call
{
    public class CreateCallRequest
    {
        public string PatientFIO { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string FlatNumber { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public int CallerId { get; set; }

        public string PhoneNumber { get; set; }

        public int DispatcherId { get; set; }

        public int DiagnosisId { get; set; }

        public DateTime DateTimeReception { get; set; }

        public string CallNotes { get; set; }

        public string CallType { get; set; }
    }
}
