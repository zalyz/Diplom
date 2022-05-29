using Ambulance.Domain;
using Ambulance.Domain.Models.ServiceModels;
using MediatR;
using System;

namespace ServiceAPI.ServiceHandlers
{
    public class AddStreetCommand : MessageBase<AddStreetRequest>, IRequest<Guid>
    {
        public AddStreetCommand(AddStreetRequest request)
            : base(request)
        {
        }
    }
}
