using Ambulance.Domain;
using MediatR;
using System;

namespace CallAPI.Brigade
{
    public class ReturnCallCommand : MessageBase<int>, IRequest<Guid>
    {
        public ReturnCallCommand(int request)
            : base(request)
        {
        }
    }
}
