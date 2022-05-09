using Ambulance.Domain;
using Ambulance.Domain.Models.ServiceModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace ServiceAPI.ServiceHandlers
{
    public class GetDiagnosisQuery : MessageBase<Guid>, IRequest<List<Diagnosis>>
    {
        public GetDiagnosisQuery(Guid request)
            : base(request)
        {
        }
    }
}
