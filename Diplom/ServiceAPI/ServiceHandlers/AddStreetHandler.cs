using Ambulance.DAL.CallAPI;
using Ambulance.DAL.CallAPI.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAPI.ServiceHandlers
{
    public class AddStreetHandler : IRequestHandler<AddStreetCommand, Guid>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public AddStreetHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Guid> Handle(AddStreetCommand request, CancellationToken cancellationToken)
        {
            await _databaseProvider.InDatabaseScope(context => context.Streets.AddAsync(new StreetEntity
            {
                Name = request.Request.Name,
            }), cancellationToken);

            return Guid.NewGuid();
        }
    }
}
