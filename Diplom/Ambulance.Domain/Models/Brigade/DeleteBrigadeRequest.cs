using System;

namespace Ambulance.Domain.Models.Brigade
{
    public class DeleteBrigadeRequest
    {
        public int Id { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
