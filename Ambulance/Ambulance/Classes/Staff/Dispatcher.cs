using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambulance.Classes.Staff
{
    public class Dispatcher : Worker
    {
        public override string GetPosition => "Диспетчер";
    }
}
