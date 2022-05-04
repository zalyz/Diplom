using Ambulance.DAL.CallAPI;
using Ambulance.DAL.CallAPI.Models;
using Ambulance.Domain.Models.Enums;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Brigade
{
    public class CreateBrigadeHandler : IRequestHandler<CreateBrigadeCommand, int>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public CreateBrigadeHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<int> Handle(CreateBrigadeCommand request, CancellationToken cancellationToken)
        {
            var brigade = request.Request.Adapt<AmbulanceBrigadeEntity>();
            brigade.Status = (byte)BrigadeStatus.Active;
            var entity = await _databaseProvider.InDatabaseScope(context => context.AmbulanceBrigades.AddAsync(brigade), cancellationToken);
            return entity.Entity.Id;
        }
    }
}
