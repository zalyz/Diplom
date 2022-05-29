using Ambulance.DAL.CallAPI;
using Ambulance.DAL.CallAPI.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAPI.ServiceHandlers
{
    public class AddDiagnosisHandler : IRequestHandler<AddDiagnosisCommand, Guid>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public AddDiagnosisHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Guid> Handle(AddDiagnosisCommand request, CancellationToken cancellationToken)
        {
            await _databaseProvider.InDatabaseScope(context => context.Diagnoses.AddAsync(new DiagnosisEntity
            {
                Name = request.Request.Name,
                Number = request.Request.Number,
            }), cancellationToken);

            return Guid.NewGuid();
        }
    }
}
