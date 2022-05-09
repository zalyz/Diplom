using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models;
using Mapster;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Call
{
    public class GetCallHandler : IRequestHandler<GetCallQuery, CallOfficeInfo>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetCallHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<CallOfficeInfo> Handle(GetCallQuery request, CancellationToken cancellationToken)
        {
            var resultSet = await _databaseProvider.InDatabaseScope(context =>
            {
                return from call in context.Calls
                       join patient in context.Patients on call.PatientId equals patient.Id
                       join street in context.Streets on patient.StreetId equals street.Id
                       join diagnosis in context.Diagnoses on call.DiagnosisId equals diagnosis.Id
                       join caller in context.Callers on call.CallerId equals caller.Id
                       where call.Id == request.Request
                       select new { call, patient, street, diagnosis, caller };
            }, cancellationToken);

            var item = resultSet.FirstOrDefault();
            if (item != null)
            {
                var call = item.call.Adapt<CallOfficeInfo>();
                call.FIO = item.patient.FIO;
                call.Street = item.street.Name;
                call.HouseNumber = item.patient.HouseNumber;
                call.FlatNumber = item.patient.FlatNumber;
                call.Age = item.patient.Age;
                call.Diagnosis = item.diagnosis.Name;
                call.Caller = item.caller.Name;

                return call;
            }

            throw new ArgumentException(nameof(request.Request));
        }
    }
}
