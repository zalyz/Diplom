using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace ServiceAPI.Employee
{
    public class GetDriversQuery : MessageBase<Guid>, IRequest<List<Driver>>
    {
        public GetDriversQuery(Guid request)
            : base(request)
        {
        }
    }
}
