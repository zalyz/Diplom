using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Brigade
{
    public class GetCallsHandler : IRequestHandler<GetCallsQuery, List<CallOfficeInfo>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetCallsHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<CallOfficeInfo>> Handle(GetCallsQuery request, CancellationToken cancellationToken)
        {
            var calls = await _databaseProvider.InDatabaseScope(context =>
                context.Calls.Where(e => e.AmbulanceBrigadeId == request.Request).ToListAsync(), cancellationToken);
            return calls.Adapt<List<CallOfficeInfo>>();
        }
    }
}
