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
    public class GetDrugsHandler : IRequestHandler<GetDrugsQuery, List<Drug>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetDrugsHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<Drug>> Handle(GetDrugsQuery request, CancellationToken cancellationToken)
        {
            var drugs = await _databaseProvider.InDatabaseScope(context => context.Drugs.ToListAsync(), cancellationToken);
            return drugs.Adapt<List<Drug>>();
        }
    }
}
