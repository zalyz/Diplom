using Ambulance.Domain.Models.Enums;

namespace Ambulance.Domain.Models.Call
{
    public class GetCallsRequest
    {
        public string OrganisationcCode { get; set; }

        public CallStatus CallStatus { get; set; }
    }
}
