using Ambulance.Domain;
using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Call;
using MediatR;
using System.Collections.Generic;

namespace CallAPI.Call
{
    public class FilterCallCommand : MessageBase<FilterRequest>, IRequest<List<CallFullOfficeInfo>>
    {
        public FilterCallCommand(FilterRequest request)
            : base(request)
        {
        }
    }
}
