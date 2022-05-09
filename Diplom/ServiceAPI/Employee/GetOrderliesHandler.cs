using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAPI.Employee
{
    public class GetOrderliesHandler : IRequestHandler<GetOrderliesQuery, List<Orderly>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetOrderliesHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<Orderly>> Handle(GetOrderliesQuery request, CancellationToken cancellationToken)
        {
            var result = await _databaseProvider.InDatabaseScope(context => context.Orderlies.ToListAsync(), cancellationToken);
            return result.Adapt<List<Orderly>>();
        }
    }
}
