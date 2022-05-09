using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Enums;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Brigade
{
    public class GetBrigadeHandler : IRequestHandler<GetBrigadeQuery, AmbulanceBrigade>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetBrigadeHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<AmbulanceBrigade> Handle(GetBrigadeQuery request, CancellationToken cancellationToken)
        {
            var set = await _databaseProvider.InDatabaseScope(context =>
            {
                return from brigade in context.AmbulanceBrigades
                       join doctor in context.Doktors on brigade.DoktorId equals doctor.Id
                       join firstMed in context.MedicalAssistants on brigade.FirstMedicalAssistantId equals firstMed.Id
                       join orderly in context.Orderlies on brigade.OrderlyId equals orderly.Id
                       join driver in context.Drivers on brigade.DriverId equals driver.Id
                       where brigade.Status == (byte)BrigadeStatus.Active
                       select new
                       {
                           brigade,
                           doctor,
                           firstMed,
                           orderly,
                           driver,
                       };
            }, cancellationToken);

            var item = set.First();
            var brigade = item.brigade.Adapt<AmbulanceBrigade>();
            if (item.brigade.SecondMedicalAssistantId != null && item.brigade.SecondMedicalAssistantId > 0)
            {
                var secondMed = await _databaseProvider.InDatabaseScope(context => context.MedicalAssistants.FirstAsync(e => e.Id == item.brigade.SecondMedicalAssistantId.Value), cancellationToken);
                brigade.SecondMedicalAssistantFIO = GetFIO(secondMed);
            }

            brigade.DoctorFIO = GetFIO(item.doctor);
            brigade.FirstMedicalAssistantFIO = GetFIO(item.firstMed);
            brigade.OrderlyFIO = GetFIO(item.orderly);
            brigade.DriverFIO = GetFIO(item.driver);
            return brigade.Adapt<AmbulanceBrigade>();
        }

        private static string GetFIO(Ambulance.DAL.CallAPI.Models.EmployeeBase employee)
        {
            return $"{employee.Surname} {employee.Name[0]}.{employee.MiddleName[0]}.";
        }
    }
}
