using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.Classes.Staff
{
    public class Orderly : Worker
    {
        [NotMapped]
        public override string GetPosition => "Санитар";
    }
}
