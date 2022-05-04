using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models.ServiceModels;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAPI.ServiceHandlers
{
    public class GetCallersHandler : IRequestHandler<GetCallersQuery, List<Caller>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetCallersHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<Caller>> Handle(GetCallersQuery request, CancellationToken cancellationToken)
        {
            var callers = await _databaseProvider.InDatabaseScope(context => context.Callers.ToListAsync(), cancellationToken);
            return callers.Adapt<List<Caller>>();
        }
    }
}
