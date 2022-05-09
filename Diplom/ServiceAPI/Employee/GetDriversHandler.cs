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
    public class GetDriversHandler : IRequestHandler<GetDriversQuery, List<Driver>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetDriversHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<Driver>> Handle(GetDriversQuery request, CancellationToken cancellationToken)
        {
            var result = await _databaseProvider.InDatabaseScope(context => context.Drivers.ToListAsync(), cancellationToken);
            return result.Adapt<List<Driver>>();
        }
    }
}
