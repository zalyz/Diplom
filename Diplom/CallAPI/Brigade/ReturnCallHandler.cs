using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Brigade
{
    public class ReturnCallHandler : IRequestHandler<ReturnCallCommand, Guid>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public ReturnCallHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Guid> Handle(ReturnCallCommand request, CancellationToken cancellationToken)
        {
            var call = await _databaseProvider.InDatabaseScope(context => context.Calls.FirstAsync(e => e.AmbulanceBrigadeId.HasValue &&
                e.AmbulanceBrigadeId.Value == request.Request
                && e.Status == (byte)CallStatus.TransferedToBrigade), cancellationToken);
            call.AmbulanceBrigadeId = null;
            call.Status = (byte)CallStatus.Accepted;
            _ = await _databaseProvider.InDatabaseScope(context => context.Calls.Update(call), cancellationToken);
            return Guid.NewGuid();
        }
    }
}
