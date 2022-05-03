using System;

namespace Ambulance.Domain.Models
{
    public class CallOfficeInfo
    {
        public int Id { get; set; }

        public int CallNumber { get; set; }

        public string FIO { get; set; }

        public string Street { get; set; }

        public string HomeNumber { get; set; }

        public string FlatNumber { get; set; }

        public int Age { get; set; }

        public string Diagnosis { get; set; }

        public string Caller { get; set; }

        public DateTime DateTimeReception { get; set; }

        public DateTime TransferDateTime { get; set; }

        public int DispatcherId { get; set; }

        public int TransferingDispatcherId { get; set; }

        public string CallNotes { get; set; }
    }
}
