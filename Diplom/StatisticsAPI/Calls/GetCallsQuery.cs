using Ambulance.Domain;
using Ambulance.Domain.Models.Statistics;
using MediatR;
using System;
using System.Collections.Generic;

namespace StatisticsAPI.Calls
{
    public class GetCallsQuery : MessageBase<Guid>, IRequest<List<CallFullInfo>>
    {
        public GetCallsQuery(Guid request)
            : base(request)
        {
        }
    }
}
