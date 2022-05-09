using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace ServiceAPI.Employee
{
    public class GetDoktorsQuery : MessageBase<Guid>, IRequest<List<Doktor>>
    {
        public GetDoktorsQuery(Guid request)
            : base(request)
        {
        }
    }
}
