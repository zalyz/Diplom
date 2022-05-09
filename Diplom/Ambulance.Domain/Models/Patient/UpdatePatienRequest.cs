namespace Ambulance.Domain.Models.Patients
{
    public class UpdatePatienRequest
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public int Age { get; set; }

        public int StreetId { get; set; }

        public string HouseNumber { get; set; }

        public string FlatNumber { get; set; }

        public byte Gender { get; set; }

        public string PassportNumber { get; set; }
    }
}
