using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace ServiceAPI.ServiceHandlers
{
    public class GetResultsQuery : MessageBase<Guid>, IRequest<List<Result>>
    {
        public GetResultsQuery(Guid request)
            : base(request)
        {
        }
    }
}
