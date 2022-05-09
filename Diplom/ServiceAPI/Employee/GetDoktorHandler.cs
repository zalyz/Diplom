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
    public class GetDoktorHandler : IRequestHandler<GetDoktorsQuery, List<Doktor>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetDoktorHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<Doktor>> Handle(GetDoktorsQuery request, CancellationToken cancellationToken)
        {
            var doktors = await _databaseProvider.InDatabaseScope(context => context.Doktors.ToListAsync(), cancellationToken);
            return doktors.Adapt<List<Doktor>>();
        }
    }
}
