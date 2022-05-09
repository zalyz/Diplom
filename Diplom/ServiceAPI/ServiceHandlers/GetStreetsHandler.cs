using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models.ServiceModels;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAPI.ServiceHandlers
{
    public class GetStreetsHandler : IRequestHandler<GetStreetsQuery, List<Street>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetStreetsHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<Street>> Handle(GetStreetsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var streets = await _databaseProvider.InDatabaseScope(context => context.Streets.ToListAsync(), cancellationToken);
                return streets.Adapt<List<Street>>();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
