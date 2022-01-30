using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.Classes.Staff
{
    public class MedicalAssistant : Worker
    {
        [NotMapped]
        public override string GetPosition => "Фельдшер";
    }
}
