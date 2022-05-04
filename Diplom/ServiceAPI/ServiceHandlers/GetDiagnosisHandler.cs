using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models.ServiceModels;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAPI.ServiceHandlers
{
    public class GetDiagnosisHandler : IRequestHandler<GetDiagnosisQuery, List<Diagnosis>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetDiagnosisHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<Diagnosis>> Handle(GetDiagnosisQuery request, CancellationToken cancellationToken)
        {
            var diagnosies = await _databaseProvider.InDatabaseScope(context => context.Diagnoses.ToListAsync(), cancellationToken);
            return diagnosies.Adapt<List<Diagnosis>>();
        }
    }
}
