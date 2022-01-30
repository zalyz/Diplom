using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Ambulance.Classes.Staff;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Ambulance.Classes
{
    [Owned]
    public class AmbulanceBrigade
    {
        public uint Number { get;  set; }

        public string Doktor { get;  set; }

        public string MedicalAssistants1 { get;  set; }

        public string MedicalAssistants2 { get;  set; }

        public string Orderly { get;  set; }

        public string Driver { get;  set; }

        public string BrigadeType { get; set; }

        public string StationName { get;  set; }

        [NotMapped]
        public string StreetOfLastCall { get; set; }

        [NotMapped]
        public string HouseNumberOfLastCall { get; set; }

        [NotMapped]
        public string NumberOfLastCall { get; set; }

        [NotMapped]
        public string ActionTime { get; set; }
        
        [NotMapped]
        public string ActionDate { get; set; }

        [NotMapped]
        public bool IsOnCall { get; set; }

        [NotMapped]
        public List<AmbulanceCall> AmbulanceCalls { get; } = new List<AmbulanceCall>();

        public void AtTheStation()
        {
            StreetOfLastCall = "";
            HouseNumberOfLastCall = "";
            NumberOfLastCall = " ";
            ActionTime = DateTime.Now.ToString("hh:mm");
            ActionDate = DateTime.Now.Date.ToString("dd.MM.yyyy");
        }

        public void SendCall(AmbulanceCall ambulanceCall)
        {
            AmbulanceCalls.Add(ambulanceCall);
            OnACall();
        }

        private void OnACall()
        {
            StreetOfLastCall = AmbulanceCalls.Last().Patient.Street;
            HouseNumberOfLastCall = AmbulanceCalls.Last().Patient.HouseNumber;
            NumberOfLastCall = AmbulanceCalls.Last().CallNumber.ToString();
            ActionTime = DateTime.Now.ToString("hh:mm");
            ActionDate = DateTime.Now.Date.ToString("dd.MM.yyyy");
        }

    }
}
