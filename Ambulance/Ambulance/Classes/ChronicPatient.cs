using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ambulance.Classes
{
    class ChronicPatient
    {
        [Key]
        public int Id { get; set; }

        public string FIO { get; set; }

        public double Age { get; set; }

        public string Diagnosis { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string FlatNumber { get; set; }

        public string Gender { get; set; }

        public string WhoCalled { get; set; }

        public string Urgency { get; set; }

        public string Notes { get; set; }

        public override string ToString()
        {
            string patientInfrmation = FIO + "/" +
                Age + "/" +
                Street + "/" +
                HouseNumber + "/" +
                FlatNumber + "/" +
                Diagnosis;
            return patientInfrmation;
        }

    }
}
