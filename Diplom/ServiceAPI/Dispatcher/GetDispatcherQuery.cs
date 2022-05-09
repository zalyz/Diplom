using Ambulance.Domain;
using MediatR;

namespace ServiceAPI.Dispatcher
{
    public class GetDispatcherQuery : MessageBase<int>, IRequest<Ambulance.Domain.Models.Dispatcher>
    {
        public GetDispatcherQuery(int request)
            : base(request)
        {
        }
    }
}
