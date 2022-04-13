using Ambulance.Domain;
using Ambulance.Domain.Models.Call;
using MediatR;

namespace CallAPI.CreateCall
{
    public class CreateCallCommand : MessageBase<CreateCallRequest>, IRequest<int>
    {
        public CreateCallCommand(CreateCallRequest createCallRequest)
            : base(createCallRequest)
        {
        }
    }
}
