using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ambulance.Classes;

namespace Ambulance.Classes
{
    class IncidentalCall : Call
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override double CallNumber { get; set; }

        public uint ProcessedCallId { get; set; }
    }
}
