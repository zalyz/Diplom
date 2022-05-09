using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace ServiceAPI.ServiceHandlers
{
    public class GetPlacesQuery : MessageBase<Guid>, IRequest<List<Place>>
    {
        public GetPlacesQuery(Guid request)
            : base(request)
        {
        }
    }
}
