using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;

namespace CallAPI.Brigade
{
    public class GetBrigadeQuery : MessageBase<int>, IRequest<AmbulanceBrigade>
    {
        public GetBrigadeQuery(int request)
            : base(request)
        {
        }
    }
}
