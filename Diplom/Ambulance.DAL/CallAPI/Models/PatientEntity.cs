using Ambulance.DAL.CallAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.DAL.CallAPI.Models
{
    [Table("Patients")]
    public class PatientEntity
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public int Age { get; set; }

        public Address HisAddress{ get; set; }

        public Gender Gender { get; set; }

        [MaxLength(10, ErrorMessage = "Passport number is more then 10 characters.")]
        public string PassportNumber { get; set; }

        [ComplexType]
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

            [MaxLength(500, ErrorMessage = "Street more then 500 characters.")]
            public string Street { get; set; }

            [MaxLength(20, ErrorMessage = "House number is more then 20 characters.")]
            public string HouseNumber { get; set; }

            [MaxLength(20, ErrorMessage = "Flat number is more then 20 characters.")]
            public string FlatNumber { get; set; }
        }
    }
}
