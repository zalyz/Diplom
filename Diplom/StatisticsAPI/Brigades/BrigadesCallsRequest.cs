using Ambulance.Domain;
using MediatR;
using System;

namespace StatisticsAPI.Brigades
{
    public class BrigadesCallsRequest : MessageBase<Guid>, IRequest<byte[]>
    {
        public BrigadesCallsRequest(Guid request)
            : base(request)
        {
        }
    }
}
