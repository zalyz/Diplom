using Ambulance.Domain;
using MediatR;
using System;

namespace StatisticsAPI.Calls
{
    public class AgeDiagnosisRequest : MessageBase<Guid>, IRequest<Guid>
    {
        public AgeDiagnosisRequest(Guid request)
            : base(request)
        {
        }
    }
}
