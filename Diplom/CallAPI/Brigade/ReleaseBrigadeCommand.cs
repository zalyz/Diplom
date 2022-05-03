using Ambulance.Domain;
using MediatR;
using System;

namespace CallAPI.Brigade
{
    public class ReleaseBrigadeCommand : MessageBase<int>, IRequest<Guid>
    {
        public ReleaseBrigadeCommand(int request)
            : base(request)
        {
        }
    }
}
