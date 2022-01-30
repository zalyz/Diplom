using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.Classes.Staff
{
    public class Driver : Worker
    {
        [NotMapped]
        public override string GetPosition => "Водитель";
    }
}
