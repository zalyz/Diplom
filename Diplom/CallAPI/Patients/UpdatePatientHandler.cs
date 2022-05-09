using Ambulance.DAL.CallAPI;
using Ambulance.DAL.CallAPI.Models;
using Mapster;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Patients
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientQuery, Guid>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public UpdatePatientHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Guid> Handle(UpdatePatientQuery request, CancellationToken cancellationToken)
        {
            var patient = request.Request.Adapt<PatientEntity>();
            await _databaseProvider.InDatabaseScope(context => context.Patients.Update(patient), cancellationToken);
            return Guid.NewGuid();
        }
    }
}
