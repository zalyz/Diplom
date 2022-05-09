using System;

namespace Ambulance.Domain.Models.Brigade
{
    public class AssignCallRequest
    {
        public int BrigadeId { get; set; }

        public int CallId { get; set; }

        public DateTime TransferDateTime { get; set; }

        public int TransferingDispatcherId { get; set; }
    }
}
