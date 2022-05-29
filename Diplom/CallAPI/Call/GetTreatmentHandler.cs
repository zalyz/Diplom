using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace CallAPI.Call
{
    public class GetTreatmentHandler : IRequestHandler<GetTreatmentQuery, List<Treatment>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetTreatmentHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<Treatment>> Handle(GetTreatmentQuery request, CancellationToken cancellationToken)
        {
            var treatment = await _databaseProvider.InDatabaseScope(context =>
            {
                return from t in context.Treatments
                       join d in context.Drugs on t.DrugId equals d.Id
                       select d;
            }, cancellationToken);

            return treatment.Select(e => new Treatment
            {
                NameAndDosage = e.Name + " " + e.Dosage,
            }).ToList();
        }
    }
}
