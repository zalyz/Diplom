using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAPI.ServiceHandlers
{
    public class GetResultsHandler : IRequestHandler<GetResultsQuery, List<Result>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetResultsHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<Result>> Handle(GetResultsQuery request, CancellationToken cancellationToken)
        {
            var results = await _databaseProvider.InDatabaseScope(context => context.Results.ToListAsync(), cancellationToken);
            return results.Adapt<List<Result>>();
        }
    }
}
