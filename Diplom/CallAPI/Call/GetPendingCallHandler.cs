using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Enums;
using Mapster;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Call
{
    public class GetPendingCallHandler : IRequestHandler<GetPendingCallQuery, List<CallFullOfficeInfo>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetPendingCallHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<CallFullOfficeInfo>> Handle(GetPendingCallQuery request, CancellationToken cancellationToken)
        {
            var calls = (await _databaseProvider
                .InDatabaseScope(context => context.Calls.Where(e => e.Status == (byte)CallStatus.PendingForProcessing), cancellationToken)).ToList();
            return calls.Adapt<List<CallFullOfficeInfo>>();
        }
    }
}
