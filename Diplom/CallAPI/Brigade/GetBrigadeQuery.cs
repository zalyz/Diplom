using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace CallAPI.Brigade
{
    public class GetBrigadeQuery : MessageBase<Guid>, IRequest<List<AmbulanceBrigade>>
    {
        public GetBrigadeQuery(Guid request)
            : base(request)
        {
        }
    }
}
