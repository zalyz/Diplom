using Ambulance.Domain;
using Ambulance.Domain.Models.Call;
using MediatR;

namespace CallAPI.CreateCall
{
    public class CreateCallCommand : MessageBase, IRequest<int>
    {
        public CreateCallCommand(string organisationCode)
            : base(organisationCode)
        {
        }

        public CreateCallRequest CreateCallRequest { get; set; }
    }
}
