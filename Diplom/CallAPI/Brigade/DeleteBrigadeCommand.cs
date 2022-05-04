using Ambulance.Domain;
using MediatR;
using System;

namespace CallAPI.Brigade
{
    public class DeleteBrigadeCommand : MessageBase<int>, IRequest<Guid>
    {
        public DeleteBrigadeCommand(int request)
            : base(request)
        {
        }
    }
}
