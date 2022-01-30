using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.Classes.Staff
{
    public abstract class Worker
    {
        [Key]
        public int Id { get; set; }

        public string Name { get;  set; }

        public string Surname { get;  set; }

        public string MiddleName { get;  set; }

        [NotMapped]
        public string FIO
        {
            get
            {
                return Surname + " " + Name + " " + MiddleName;
            }
        }

        [NotMapped]
        public abstract string GetPosition { get; }

        public override string ToString()
        {
            return Surname + " " + Name[0] + ". " + MiddleName[0] + ".";
            
        }
    }
}
