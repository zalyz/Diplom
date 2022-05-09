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
    public class GetPlacesHandler : IRequestHandler<GetPlacesQuery, List<Place>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetPlacesHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<Place>> Handle(GetPlacesQuery request, CancellationToken cancellationToken)
        {
            var places = await _databaseProvider.InDatabaseScope(context => context.Places.ToListAsync(), cancellationToken);
            return places.Adapt<List<Place>>();
        }
    }
}
