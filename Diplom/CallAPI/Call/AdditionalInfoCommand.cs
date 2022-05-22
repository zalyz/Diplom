using Ambulance.Domain;
using Ambulance.Domain.Models.Call;
using MediatR;
using System;

namespace CallAPI.Call
{
    public class AdditionalInfoCommand : MessageBase<AdditionalInfoRequest>, IRequest<Guid>
    {
        public AdditionalInfoCommand(AdditionalInfoRequest request)
            : base(request)
        {
        }
    }
}
