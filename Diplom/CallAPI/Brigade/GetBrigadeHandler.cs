using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Enums;
using Mapster;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Brigade
{
    public class GetBrigadeHandler : IRequestHandler<GetBrigadeQuery, List<AmbulanceBrigade>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetBrigadeHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<AmbulanceBrigade>> Handle(GetBrigadeQuery request, CancellationToken cancellationToken)
        {
            var brigades = (await _databaseProvider.InDatabaseScope(context => context.AmbulanceBrigades.Where(e => e.Status == (byte)BrigadeStatus.Active).ToList(), cancellationToken))
                .Adapt<List<AmbulanceBrigade>>();
            var calls = await _databaseProvider.InDatabaseScope(context => context.Calls.Where(e => e.Status == (byte)CallStatus.TransferedToBrigade
                && !e.AmbulanceBrigadeId.HasValue).ToList(), cancellationToken);
            brigades.ForEach(b =>
            {
                var call = calls.FirstOrDefault(e => e.AmbulanceBrigadeId == b.Id);
                if (call != null)
                {
                    b.CallId = call.Id;
                }
            });

            return brigades;
        }
    }
}
