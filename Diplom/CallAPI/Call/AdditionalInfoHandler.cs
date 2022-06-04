using Ambulance.DAL.CallAPI;
using Ambulance.DAL.CallAPI.Models;
using Mapster;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Call
{
    public class AdditionalInfoHandler : IRequestHandler<AdditionalInfoCommand, Guid>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public AdditionalInfoHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Guid> Handle(AdditionalInfoCommand request, CancellationToken cancellationToken)
        {
            var info = request.Request.Adapt<CallAdditionalInfoEntity>();
            await _databaseProvider.InDatabaseScope(context => context.CallAdditionalInfo.AddAsync(info), cancellationToken);
            return Guid.NewGuid();
        }
    }
}
