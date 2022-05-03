using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace CallAPI.Call
{
    public class GetAcceptedCallsQuery : MessageBase<Guid>, IRequest<List<CallOfficeInfo>>
    {
        public GetAcceptedCallsQuery(Guid request)
            : base(request)
        {
        }
    }
}
