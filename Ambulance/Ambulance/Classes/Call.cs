using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ambulance.Classes
{
    public abstract class Call
    {
        public abstract double CallNumber { get; set; }

        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        public string Diagnosis { get; set; }

        public string Results { get; set; }

        public AmbulanceBrigade AmbulanceBrigade { get; set; }

        public DateTime DateTimeReception { get; set; }

        public DateTime TransferDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public DateTime ComeBackDateTime { get; set; }

        public string TransferringDispatcher { get; set; }

        public string ProcessingDispatcher { get; set; }

        public int KilometrageBefor { get; set; }

        public int KilometrageAfter { get; set; }

        public string Place { get; set; }

        public string CallNotes { get; set; }

        public string CallType { get; set; }

        public string Treatment { get; set; }
    }
}
