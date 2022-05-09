using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;

namespace CallAPI.Call
{
    public class GetCallQuery : MessageBase<int>, IRequest<CallOfficeInfo>
    {
        public GetCallQuery(int request)
            : base(request)
        {
        }
    }
}
