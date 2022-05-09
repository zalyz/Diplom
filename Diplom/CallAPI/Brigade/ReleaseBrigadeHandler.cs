using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Brigade
{
    public class ReleaseBrigadeHandler : IRequestHandler<ReleaseBrigadeCommand, Guid>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public ReleaseBrigadeHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Guid> Handle(ReleaseBrigadeCommand request, CancellationToken cancellationToken)
        {
            var call = await _databaseProvider.InDatabaseScope(context => context.Calls.FirstAsync(e => e.AmbulanceBrigadeId.HasValue &&
                e.AmbulanceBrigadeId.Value == request.Request
                && e.Status == (byte)CallStatus.TransferedToBrigade), cancellationToken);
            call.Status = (byte)CallStatus.PendingForProcessing;
            _ = await _databaseProvider.InDatabaseScope(context => context.Calls.Update(call), cancellationToken);
            return Guid.NewGuid();
        }
    }
}
