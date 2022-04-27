using Ambulance.DAL.CallAPI;
using Ambulance.DAL.CallAPI.Models;
using MediatR;
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
            var patient = new PatientEntity
            {
                FIO = request.Request.PatientFIO,
                Age = request.Request.Age,
                Gender = request.Request.Gender,
                HisAddress = new PatientEntity.Address
                {
                    Street = request.Request.Street,
                    FlatNumber = request.Request.FlatNumber,
                    HouseNumber = request.Request.HouseNumber,
                },
            };
            var call = new CallEntity
            {
                PatientId = patient.Id,
            };
            var result = await _databaseProvider.InDatabaseScope(context => context.Calls.AddAsync(new CallEntity()));
            return result.Entity.Id;
        }
    }
}
