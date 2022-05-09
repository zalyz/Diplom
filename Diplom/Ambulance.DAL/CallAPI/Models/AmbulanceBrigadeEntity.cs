using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.DAL.CallAPI.Models
{
    [Table("AmbulanceBrigades")]
    public class AmbulanceBrigadeEntity
    {
        public int Id { get; set; }

        public int? DoktorId { get; set; }

        public int FirstMedicalAssistantId { get; set; }

        public int? SecondMedicalAssistantId { get; set; }

        public int DriverId { get; set; }

        public int? OrderlyId { get; set; }

        public int Number { get; set; }

        public byte BrigadeType { get; set; }

        public DateTime DateTimeStart { get; set; }

        public DateTime DateTimeEnd { get; set; }

        [MaxLength(50, ErrorMessage = "Station name is more then 50 characters.")]
        public string StationName { get; set; }

        public byte Status { get; set; }
    }
}
