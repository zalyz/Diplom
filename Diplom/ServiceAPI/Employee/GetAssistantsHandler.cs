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
    public class GetAssistantsHandler : IRequestHandler<GetAssistantsQuery, List<MedicalAssistant>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetAssistantsHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<MedicalAssistant>> Handle(GetAssistantsQuery request, CancellationToken cancellationToken)
        {
            var result = await _databaseProvider.InDatabaseScope(context => context.MedicalAssistants.ToListAsync(), cancellationToken);
            return result.Adapt<List<MedicalAssistant>>();
        }
    }
}
