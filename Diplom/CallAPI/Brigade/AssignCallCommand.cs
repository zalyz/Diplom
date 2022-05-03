using Ambulance.Domain;
using Ambulance.Domain.Models.Brigade;
using MediatR;
using System;

namespace CallAPI.Brigade
{
    public class AssignCallCommand : MessageBase<AssignCallRequest>, IRequest<Guid>
    {
        public AssignCallCommand(AssignCallRequest request)
            : base(request)
        {
        }
    }
}
