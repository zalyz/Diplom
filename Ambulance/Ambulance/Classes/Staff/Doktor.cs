using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.Classes.Staff
{
    public class Doktor : Worker
    {
        [NotMapped]
        public override string GetPosition => "Врач";
    }
}
