using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace CallAPI.Brigade
{
    public class GetBrigadeMonitoringInfosQuery : MessageBase<Guid>, IRequest<List<BrigadeMonitoringInfo>>
    {
        public GetBrigadeMonitoringInfosQuery(Guid request)
            : base(request)
        {
        }
    }
}
