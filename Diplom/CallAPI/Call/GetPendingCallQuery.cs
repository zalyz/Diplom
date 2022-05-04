using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace CallAPI.Call
{
    public class GetPendingCallQuery : MessageBase<Guid>, IRequest<List<CallFullOfficeInfo>>
    {
        public GetPendingCallQuery(Guid request)
            : base(request)
        {
        }
    }
}
