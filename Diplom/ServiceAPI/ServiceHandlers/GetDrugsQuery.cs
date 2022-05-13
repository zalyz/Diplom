using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace ServiceAPI.ServiceHandlers
{
    public class GetDrugsQuery : MessageBase<Guid>, IRequest<List<Drug>>
    {
        public GetDrugsQuery(Guid request)
            : base(request)
        {
        }
    }
}
