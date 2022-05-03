using Ambulance.DAL.CallAPI;
using Ambulance.DAL.CallAPI.Models;
using Mapster;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Call
{
    public class ProcessCallHandler : IRequestHandler<ProcessCallCommand, Guid>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public ProcessCallHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Guid> Handle(ProcessCallCommand request, CancellationToken cancellationToken)
        {
            var callEntity = request.Request.Adapt<CallEntity>();
            await _databaseProvider.InDatabaseScope(context => context.Calls.Update(callEntity), cancellationToken);
            return Guid.NewGuid();
        }
    }
}
