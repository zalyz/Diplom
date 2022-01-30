using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ambulance.Classes
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        public string FIO { get;  set; }

        public double Age { get;  set; }

        public string Street { get;  set; }

        public string HouseNumber { get;  set; }

        public string FlatNumber { get;  set; }

        public string Gender { get; set; }

        public override string ToString()
        {
            string patientInfrmation = FIO + "/" +
                Age + "/" +
                Street + "/" +
                HouseNumber + "/" +
                FlatNumber + "/";
            return patientInfrmation;
        }
    }
}
