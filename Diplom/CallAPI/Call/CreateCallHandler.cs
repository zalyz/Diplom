using Ambulance.DAL.CallAPI;
using Ambulance.DAL.CallAPI.Models;
using Mapster;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Call
{
    public class CreateCallHandler : IRequestHandler<CreateCallCommand, int>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public CreateCallHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<int> Handle(CreateCallCommand request, CancellationToken cancellationToken)
        {
            var patient = request.Request.Adapt<PatientEntity>();
            await _databaseProvider.InDatabaseScopeValue(context => context.Patients.AddAsync(patient), cancellationToken);
            var call = request.Request.Adapt<CallEntity>();
            var count = await _databaseProvider.InDatabaseScope(context => context.Calls.Count(), cancellationToken);
            call.PatientId = patient.Id;
            call.CallNumber = count + 1;
            var result = await _databaseProvider.InDatabaseScopeValue(context => context.Calls.AddAsync(call), cancellationToken);
            return result.Entity.Id;
        }
    }
}
