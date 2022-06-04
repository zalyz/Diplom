using Ambulance.Domain;
using MediatR;
using System;

namespace StatisticsAPI.Calls
{
    public class AgeDiagnosisRequest : MessageBase<Guid>, IRequest<byte[]>
    {
        public AgeDiagnosisRequest(Guid request)
            : base(request)
        {
        }
    }
}
