using System;
using System.Collections.Generic;
using System.ComponentModel;
using Ambulance.Classes.Staff;

namespace Ambulance.Classes
{
    public class AmbulanceCall
    {
        public uint CallNumber { get;  set; }

        public Patient Patient { get;  set; }

        public string Diagnosis { get; set; }

        public DateTime DateTimeReception { get;  set; }

        public DateTime TransferDateTime { get;  set; }
        
        public string CallNotes { get;  set; }

        public string WhoCalled { get;  set; }

        public string Type { get;  set; }

        public string ReceivingDispatcher { get; set; }

        public string TransferringDispatcher { get; set; }

        public string Department { get; set; }

        public static uint _nextcallNumber;

        public AmbulanceCall(Patient patient, DateTime reception, string diagnosis, string callNotes, string whoCalled, string type)
        {
            CallNumber = _nextcallNumber;
            _nextcallNumber++;
            Patient = patient;
            Diagnosis = diagnosis;
            CallNotes = callNotes;
            WhoCalled = whoCalled;
            DateTimeReception = reception;
            Type = type;
        }

        public static void UpdateCallNumber()
        {
            _nextcallNumber = 1;
        }

        public override string ToString()
        {
            string callInformation = CallNumber + "|" +
                Patient + "|" +
                DateTimeReception + "|" +
                TransferDateTime + "|" +
                CallNotes + "|" +
                WhoCalled;
            return callInformation;
        }
    }
}
