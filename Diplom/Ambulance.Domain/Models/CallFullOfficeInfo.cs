using Ambulance.Domain.Models.Enums;
using System;

namespace Ambulance.Domain.Models
{
    public class CallFullOfficeInfo
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string FIO { get; set; }

        public int Age { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string FlatNumber { get; set; }

        public Gender Gender { get; set; }

        public int? AmbulanceBrigadeId { get; set; }

        public string DoktorFIO { get; set; }

        public string FirstMedicalAssistantFIO { get; set; }

        public string SecondMedicalAssistantFIO { get; set; }

        public string OrderlyFIO { get; set; }

        public string DriverFIO { get; set; }

        public int BrigadeNumber { get; set; }

        public int CallNumber { get; set; }

        public string ResultId { get; set; }

        public string Result { get; set; }

        public int DiagnosisId { get; set; }

        public string Diagnosis { get; set; }

        public int CallerId { get; set; }

        public string Caller { get; set; }

        public DateTime DateTimeReception { get; set; }

        public DateTime TransferDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public DateTime ComeBackDateTime { get; set; }

        public int KilometrageBefor { get; set; }

        public int KilometrageAfter { get; set; }

        public string PlaceId { get; set; }

        public string Place { get; set; }

        public string CallNotes { get; set; }

        public string CallType { get; set; }
    }
}
