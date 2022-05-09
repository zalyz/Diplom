using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace ServiceAPI.Employee
{
    public class GetAssistantsQuery : MessageBase<Guid>, IRequest<List<MedicalAssistant>>
    {
        public GetAssistantsQuery(Guid request)
            : base(request)
        {
        }
    }
}
