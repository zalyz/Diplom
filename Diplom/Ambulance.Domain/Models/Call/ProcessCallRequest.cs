using System;

namespace Ambulance.Domain.Models.Call
{
    public class ProcessCallRequest
    {
        public int Id { get; set; }

        public int CallNumber { get; set; }

        public int PatientId { get; set; }

        public int AmbulanceBrigadeId { get; set; }

        public int DispatcherId { get; set; }

        public string PhoneNumber { get; set; }

        public int ResultId { get; set; }

        public int DiagnosisId { get; set; }

        public int CallerId { get; set; }

        public DateTime DateTimeReception { get; set; }

        public DateTime TransferDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public DateTime ComeBackDateTime { get; set; }

        public int TransferringDispatcherId { get; set; }

        public int ProcessingDispatcherid { get; set; }

        public int KilometrageBefor { get; set; }

        public int KilometrageAfter { get; set; }

        public int PlaceId { get; set; }

        public string CallNotes { get; set; }
    }
}
