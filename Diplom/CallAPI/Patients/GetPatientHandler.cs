using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Patients
{
    public class GetPatientHandler : IRequestHandler<GetPatientQuery, Patient>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetPatientHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Patient> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            var patient = await _databaseProvider.InDatabaseScope(context => context.Patients.FirstOrDefaultAsync(e => e.Id == request.Request), cancellationToken);
            if (patient != null)
            {
                return patient.Adapt<Patient>();
            }

            throw new ArgumentException("Пациент не найдет");
        }
    }
}
