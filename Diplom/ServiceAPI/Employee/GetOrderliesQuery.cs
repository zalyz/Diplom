using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace ServiceAPI.Employee
{
    public class GetOrderliesQuery : MessageBase<Guid>, IRequest<List<Orderly>>
    {
        public GetOrderliesQuery(Guid request)
            : base(request)
        {
        }
    }
}
