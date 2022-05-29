using Ambulance.Domain;
using MediatR;
using System;

namespace StatisticsAPI.Brigades
{
    public class BrigadesCallsRequest : MessageBase<Guid>, IRequest<Guid>
    {
        public BrigadesCallsRequest(Guid request)
            : base(request)
        {
        }
    }
}
