using Ambulance.DAL.CallAPI;
using Ambulance.DAL.CallAPI.Models;
using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Enums;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Brigade
{
    public class GetBrigadesHandler : IRequestHandler<GetBrigadesQuery, List<AmbulanceBrigade>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetBrigadesHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<AmbulanceBrigade>> Handle(GetBrigadesQuery request, CancellationToken cancellationToken)
        {
            var brigadesSet = await _databaseProvider.InDatabaseScope(context =>
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

            var brigades = new List<AmbulanceBrigade>();
            foreach (var item in brigadesSet)
            {
                var brigade = item.brigade.Adapt<AmbulanceBrigade>();
                //////if (item.brigade.SecondMedicalAssistantId.HasValue && item.brigade.SecondMedicalAssistantId.Value > 0)
                //////{
                //////    var secondMed = await _databaseProvider.InDatabaseScope(context => context.MedicalAssistants.First(e => e.Id == item.brigade.SecondMedicalAssistantId.Value), cancellationToken);
                //////    brigade.SecondMedicalAssistantFIO = GetFIO(secondMed);
                //////}

                brigade.DoctorFIO = GetFIO(item.doctor);
                brigade.FirstMedicalAssistantFIO = GetFIO(item.firstMed);
                brigade.OrderlyFIO = GetFIO(item.orderly);
                brigade.DriverFIO = GetFIO(item.driver);

                brigades.Add(brigade);
            }

            return brigades;
        }

        private static string GetFIO(Ambulance.DAL.CallAPI.Models.EmployeeBase employee)
        {
            return $"{employee.Surname} {employee.Name[0]}.{employee.MiddleName[0]}.";
        }
    }
}
