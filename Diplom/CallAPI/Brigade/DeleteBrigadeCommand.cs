using Ambulance.Domain;
using Ambulance.Domain.Models.Brigade;
using MediatR;
using System;

namespace CallAPI.Brigade
{
    public class DeleteBrigadeCommand : MessageBase<DeleteBrigadeRequest>, IRequest<Guid>
    {
        public DeleteBrigadeCommand(DeleteBrigadeRequest request)
            : base(request)
        {
        }
    }
}
