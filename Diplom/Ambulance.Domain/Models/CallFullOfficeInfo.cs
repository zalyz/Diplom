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

        public int DispatcherId { get; set; }

        public string Dispatcher { get; set; }

        public int CallNumber { get; set; }

        public int ResultId { get; set; }

        public string ResultName { get; set; }

        public int DiagnosisId { get; set; }

        public string DiagnosisName { get; set; }

        public int CallerId { get; set; }

        public DateTime DateTimeReception { get; set; }

        public DateTime TransferDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public DateTime ComeBackDateTime { get; set; }

        public int TransferingDispatcherId { get; set; }

        public string TransferingDispatcher { get; set; }

        public int ProcessingDispatcherid { get; set; }

        public string ProcessingDispatcher { get; set; }

        public int KilometrageBefore { get; set; }

        public int KilometrageAfter { get; set; }

        public int PlaceId { get; set; }

        public string CallNotes { get; set; }

        public string Type { get; set; }
    }
}
