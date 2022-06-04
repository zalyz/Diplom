using Ambulance.Domain;
using MediatR;
using System;

namespace StatisticsAPI.Calls
{
    public class DiagnosisGenderQuery : MessageBase<Guid>, IRequest<byte[]>
    {
        public DiagnosisGenderQuery(Guid request)
            : base(request)
        {
        }
    }
}
