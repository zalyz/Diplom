﻿using System;

namespace Ambulance.DAL.CallAPI.Models
{
    public class CallEntity
    {
        public int Id { get; set; }

        public int CallNumber { get; set; }

        public int PatientId { get; set; }

        public int AmbulanceBrigadeId { get; set; }

        public int DispatcherId { get; set; }

        public string Diagnosis { get; set; }

        public string Results { get; set; }

        public DateTime DateTimeReception { get; set; }

        public DateTime TransferDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public DateTime ComeBackDateTime { get; set; }

        public int TransferringDispatcherId { get; set; }

        public int ProcessingDispatcherid { get; set; }

        public int KilometrageBefor { get; set; }

        public int KilometrageAfter { get; set; }

        public string Place { get; set; }

        public string CallNotes { get; set; }

        public string CallType { get; set; }

        public bool IsProcessed { get; set; }
    }
}
