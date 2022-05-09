using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace CallAPI.Brigade
{
    public class GetBrigadesQuery : MessageBase<Guid>, IRequest<List<AmbulanceBrigade>>
    {
        public GetBrigadesQuery(Guid request)
            : base(request)
        {
        }
    }
}
