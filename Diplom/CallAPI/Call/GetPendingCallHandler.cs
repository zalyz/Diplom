using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Enums;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Call
{
    public class GetPendingCallHandler : IRequestHandler<GetPendingCallQuery, List<CallFullOfficeInfo>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetPendingCallHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<CallFullOfficeInfo>> Handle(GetPendingCallQuery request, CancellationToken cancellationToken)
        {
            var resultSet = await _databaseProvider.InDatabaseScope(context =>
            {
                return from call in context.Calls
                       join patient in context.Patients on call.PatientId equals patient.Id
                       join street in context.Streets on patient.StreetId equals street.Id
                       join diagnosis in context.Diagnoses on call.DiagnosisId equals diagnosis.Id
                       join brigade in context.AmbulanceBrigades on call.AmbulanceBrigadeId.Value equals brigade.Id
                       join doctor in context.Doktors on brigade.DoktorId equals doctor.Id
                       join firstMed in context.MedicalAssistants on brigade.FirstMedicalAssistantId equals firstMed.Id
                       join orderly in context.Orderlies on brigade.OrderlyId equals orderly.Id
                       join driver in context.Drivers on brigade.DriverId equals driver.Id
                       where call.Status == (byte)CallStatus.PendingForProcessing
                       select new
                       {
                           brigade
                       };
            }, cancellationToken);

            foreach (var item in resultSet)
            {
                var brigade = item.brigade.Adapt<AmbulanceBrigade>();
                if (item.brigade.SecondMedicalAssistantId != null && item.brigade.SecondMedicalAssistantId > 0)
                {
                    var secondMed = await _databaseProvider.InDatabaseScope(context => context.MedicalAssistants.FirstAsync(e => e.Id == item.brigade.SecondMedicalAssistantId.Value), cancellationToken);
                    brigade.SecondMedicalAssistantFIO = GetFIO(secondMed);
                }
            }

            var calls = (await _databaseProvider
                .InDatabaseScope(context => context.Calls.Where(e => e.Status == (byte)CallStatus.PendingForProcessing), cancellationToken)).ToList();
            return calls.Adapt<List<CallFullOfficeInfo>>();
        }

        private static string GetFIO(Ambulance.DAL.CallAPI.Models.EmployeeBase employee)
        {
            return $"{employee.Surname} {employee.Name[0]}.{employee.MiddleName[0]}.";
        }
    }
}
