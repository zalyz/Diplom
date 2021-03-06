using Ambulance.Domain.Models.Enums;
using System;

namespace Ambulance.Domain.Models.Call
{
    public class CreateCallRequest
    {
        public string FIO { get; set; }

        public int StreetId { get; set; }

        public string HouseNumber { get; set; }

        public string FlatNumber { get; set; }

        public int Age { get; set; }

        public int CallerId { get; set; }

        public string PhoneNumber { get; set; }

        public int DispatcherId { get; set; }

        public int DiagnosisId { get; set; }

        public DateTime DateTimeReception { get; set; }

        public string CallNotes { get; set; }

        public CallType CallType { get; set; }
    }
}
