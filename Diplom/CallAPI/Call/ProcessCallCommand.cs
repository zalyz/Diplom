using Ambulance.Domain;
using Ambulance.Domain.Models.Call;
using MediatR;
using System;

namespace CallAPI.Call
{
    public class ProcessCallCommand : MessageBase<ProcessCallRequest>, IRequest<Guid>
    {
        public ProcessCallCommand(ProcessCallRequest request)
            : base(request)
        {
        }
    }
}
