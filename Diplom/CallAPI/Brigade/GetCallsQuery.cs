using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace CallAPI.Brigade
{
    public class GetCallsQuery : MessageBase<int>, IRequest<List<CallOfficeInfo>>
    {
        public GetCallsQuery(int request)
            : base(request)
        {
        }
    }
}
