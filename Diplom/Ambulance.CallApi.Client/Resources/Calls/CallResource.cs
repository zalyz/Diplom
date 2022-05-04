using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Call;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.CallApi.Client.Resources.Calls
{
    public class CallResource : ResourceBase<ICallEndpoint>, ICallResource
    {
        public CallResource(ICallEndpoint apiClient, string tenant)
            : base(apiClient, tenant)
        {
        }

        public Task<int> CreateCall(CreateCallRequest request, CancellationToken cancellationToken = default)
        {
            return Execute<int>(token => Client.CreateCall(request, token), cancellationToken);
        }

        public Task<List<CallOfficeInfo>> GetAccepted(CancellationToken cancellationToken = default)
        {
            return Execute<List<CallOfficeInfo>>(token => Client.GetAccepted(token), cancellationToken);
        }

        public Task<List<CallFullOfficeInfo>> GetPending(CancellationToken cancellationToken = default)
        {
            return Execute<List<CallFullOfficeInfo>>(token => Client.GetPending(token), cancellationToken);
        }

        public async Task ProcessCall(ProcessCallRequest request, CancellationToken cancellationToken = default)
        {
            await Execute(token => Client.ProcessCall(request, token), cancellationToken);
        }
    }
}
