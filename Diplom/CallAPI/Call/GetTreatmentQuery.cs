using Ambulance.Domain;
using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Call;
using MediatR;
using System.Collections.Generic;

namespace CallAPI.Call
{
    public class GetTreatmentQuery : MessageBase<GetTreatmentRequest>, IRequest<List<Treatment>>
    {
        public GetTreatmentQuery(GetTreatmentRequest request)
            : base(request)
        {
        }
    }
}
