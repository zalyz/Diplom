using Ambulance.DAL.CallAPI;
using Ambulance.DAL.CallAPI.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.CreateCall
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
            var result = await _databaseProvider.InDatabaseScope(context => context.Calls.AddAsync(new CallEntity()));
            return result.Entity.Id;
        }
    }
}
