using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ambulance.Classes.Staff;

namespace Ambulance.Classes
{
    public class ProcessedCall : Call
    {
        [Key]
        public override double CallNumber { get;  set; }
    }
}
