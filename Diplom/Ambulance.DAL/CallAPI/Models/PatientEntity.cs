using Ambulance.DAL.CallAPI.Models.Enums;

namespace Ambulance.DAL.CallAPI.Models
{
    public class PatientEntity
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public int Age { get; set; }

        public Address HisAddress{ get; set; }

        public Gender Gender { get; set; }

        public class Address
        {
            public Address()
            {
            }

            public Address(string street, string houseNumber, string flatNumber)
            {
                Street = street;
                HouseNumber = houseNumber;
                FlatNumber = flatNumber;
            }

            public string Street { get; set; }

            public string HouseNumber { get; set; }

            public string FlatNumber { get; set; }
        }
    }
}
