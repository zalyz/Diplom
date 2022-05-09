using Ambulance.DAL.CallAPI;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAPI.Dispatcher
{
    public class GetDispatcherHandler : IRequestHandler<GetDispatcherQuery, Ambulance.Domain.Models.Dispatcher>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetDispatcherHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Ambulance.Domain.Models.Dispatcher> Handle(GetDispatcherQuery request, CancellationToken cancellationToken)
        {
            var dispatcher = await _databaseProvider.InDatabaseScope(context => context.Dispatchers.FirstOrDefaultAsync(e => e.Id == request.Request));
            if (dispatcher is not null)
            {
                return dispatcher.Adapt<Ambulance.Domain.Models.Dispatcher>();
            }

            throw new ArgumentException("Dispatcher not found");
        }
    }
}
