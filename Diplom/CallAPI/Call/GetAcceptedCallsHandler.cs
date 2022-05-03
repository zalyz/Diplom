using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Enums;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Call
{
    public class GetAcceptedCallsHandler : IRequestHandler<GetAcceptedCallsQuery, List<CallOfficeInfo>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetAcceptedCallsHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<CallOfficeInfo>> Handle(GetAcceptedCallsQuery request, CancellationToken cancellationToken)
        {
            var callEntities = await _databaseProvider.InDatabaseScope(context => context.Calls.Where(e => e.Status == CallStatus.Accepted), cancellationToken);
            var calls = await callEntities.ToListAsync();
            return calls.Adapt<List<CallOfficeInfo>>();
        }
    }
}
