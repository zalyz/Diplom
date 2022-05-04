using Ambulance.Domain;
using Ambulance.Domain.Models.Brigade;
using MediatR;

namespace CallAPI.Brigade
{
    public class CreateBrigadeCommand : MessageBase<CreateBrigadeRequest>, IRequest<int>
    {
        public CreateBrigadeCommand(CreateBrigadeRequest request)
            : base(request)
        {
        }
    }
}
