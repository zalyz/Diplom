using Ambulance.Domain;
using Ambulance.Domain.Models.ServiceModels;
using MediatR;
using System;

namespace ServiceAPI.ServiceHandlers
{
    public class AddDiagnosisCommand : MessageBase<AddDiagnosisRequest>, IRequest<Guid>
    {
        public AddDiagnosisCommand(AddDiagnosisRequest request)
            : base(request)
        {
        }
    }
}
