using Ambulance.DAL.CallAPI;
using Ambulance.DAL.CallAPI.Models;
using Mapster;
using MediatR;
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
            var patient = new PatientEntity
            {
                FIO = request.Request.PatientFIO,
                Age = request.Request.Age,
                Gender = request.Request.Gender,
                HisAddress = request.Request.Adapt<PatientEntity.Address>(),
            };
            await _databaseProvider.InDatabaseScope(context => context.Patients.AddAsync(patient), cancellationToken);
            var call = request.Request.Adapt<CallEntity>();
            call.PatientId = patient.Id;
            var result = await _databaseProvider.InDatabaseScope(context => context.Calls.AddAsync(call), cancellationToken);
            return result.Entity.Id;
        }
    }
}
