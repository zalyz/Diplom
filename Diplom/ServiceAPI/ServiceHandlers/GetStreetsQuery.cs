using Ambulance.Domain;
using Ambulance.Domain.Models.ServiceModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace ServiceAPI.ServiceHandlers
{
    public class GetStreetsQuery : MessageBase<Guid>, IRequest<List<Street>>
    {
        public GetStreetsQuery(Guid request)
            : base(request)
        {
        }
    }
}
