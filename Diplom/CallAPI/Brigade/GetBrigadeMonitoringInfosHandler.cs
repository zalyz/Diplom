using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using Ambulance.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace CallAPI.Brigade
{
    public class GetBrigadeMonitoringInfosHandler : IRequestHandler<GetBrigadeMonitoringInfosQuery, List<BrigadeMonitoringInfo>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetBrigadeMonitoringInfosHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<BrigadeMonitoringInfo>> Handle(GetBrigadeMonitoringInfosQuery request, CancellationToken cancellationToken)
        {
            var brigades = await _databaseProvider.InDatabaseScope(context => context.AmbulanceBrigades
                .Where(e => e.Status == (byte)BrigadeStatus.Active).ToListAsync(), cancellationToken);

            var brigadesIds = brigades.Select(e => e.Id).ToList();
            var set = await _databaseProvider.InDatabaseScope(context =>
            {
                return from call in context.Calls
                       join patient in context.Patients on call.PatientId equals patient.Id
                       join street in context.Streets on patient.StreetId equals street.Id
                       where brigadesIds.Contains(call.AmbulanceBrigadeId.Value) && call.Status == (byte)CallStatus.TransferedToBrigade
                       select new
                       {
                           call,
                           patient,
                           street
                       };
            }, cancellationToken);
            var result = brigades.Adapt<List<BrigadeMonitoringInfo>>();
            result.ForEach(x =>
            {
                var item = set.FirstOrDefault(e => e.call.AmbulanceBrigadeId == x.Id);
                if (item != null)
                {
                    x.Street = item.street.Name;
                    x.HouseNumber = item.patient.HouseNumber;
                    x.CallId = item.call.Id;
                    x.CallNumber = item.call.CallNumber;
                    x.ActionDateTime = item.call.TransferDateTime;
                }
            });

            return result;
        }
    }
}
