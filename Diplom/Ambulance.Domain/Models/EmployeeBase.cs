namespace Ambulance.Domain.Models
{
    public class EmployeeBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string FIO => $"{Surname} {Name[0]}. {MiddleName[0]}";
    }
}
