using System;
using System.Collections.Generic;
using System.Text;

namespace Ambulance.Classes.Staff
{
    class Statistician : Worker
    {
        public override string GetPosition => "Статистик";

        public string Password { get; set; }
    }
}
