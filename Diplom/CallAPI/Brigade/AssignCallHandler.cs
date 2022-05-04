using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Brigade
{
    public class AssignCallHandler : IRequestHandler<AssignCallCommand, Guid>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public AssignCallHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Guid> Handle(AssignCallCommand request, CancellationToken cancellationToken)
        {
            var call = await _databaseProvider.InDatabaseScope(context => context.Calls.FirstAsync(e => e.Id == request.Request.CallId), cancellationToken);
            call.AmbulanceBrigadeId = request.Request.BrigadeId;
            call.Status = (byte)CallStatus.TransferedToBrigade;
            _ = await _databaseProvider.InDatabaseScope(context => context.Calls.Update(call), cancellationToken);
            return Guid.NewGuid();
        }
    }
}
