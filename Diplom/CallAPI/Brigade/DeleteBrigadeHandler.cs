using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Brigade
{
    public class DeleteBrigadeHandler : IRequestHandler<DeleteBrigadeCommand, Guid>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public DeleteBrigadeHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Guid> Handle(DeleteBrigadeCommand request, CancellationToken cancellationToken)
        {
            var brigade = await _databaseProvider.InDatabaseScope(context => context.AmbulanceBrigades.FirstAsync(e => e.Id == request.Request.Id
                && e.Status == (byte)BrigadeStatus.Active), cancellationToken);
            brigade.Status = (byte)BrigadeStatus.Finished;
            brigade.DateTimeEnd = request.Request.EndDateTime;
            _ = await _databaseProvider.InDatabaseScope(context => context.AmbulanceBrigades.Update(brigade), cancellationToken);
            return Guid.NewGuid();
        }
    }
}
