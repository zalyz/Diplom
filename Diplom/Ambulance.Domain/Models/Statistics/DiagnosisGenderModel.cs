using Ambulance.Domain.Models.Enums;
using System.Collections.Generic;

namespace Ambulance.Domain.Models.Statistics
{
    public class DiagnosisGenderModel
    {
        public string Diagnosis { get; set; }

        public List<int> Ages { get; set; }

        public Gender Gender { get; set; }
    }
}
