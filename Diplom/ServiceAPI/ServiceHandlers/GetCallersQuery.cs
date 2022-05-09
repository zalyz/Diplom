using Ambulance.Domain;
using Ambulance.Domain.Models.ServiceModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace ServiceAPI.ServiceHandlers
{
    public class GetCallersQuery : MessageBase<Guid>, IRequest<List<Caller>>
    {
        public GetCallersQuery(Guid request)
            : base(request)
        {
        }
    }
}
