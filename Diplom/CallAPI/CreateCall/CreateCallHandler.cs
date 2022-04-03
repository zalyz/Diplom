using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.CreateCall
{
    public class CreateCallHandler : IRequestHandler<CreateCallCommand, int>
    {
        public Task<int> Handle(CreateCallCommand request, CancellationToken cancellationToken)
        {
            return
        }
    }
}
