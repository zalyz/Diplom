using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Call;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.CallApi.Client.Resources.Calls
{
    public interface ICallResource
    {
        Task<List<CallOfficeInfo>> GetAccepted(CancellationToken cancellationToken = default);

        Task<List<CallFullOfficeInfo>> GetPending(CancellationToken cancellationToken = default);

        Task<int> CreateCall(CreateCallRequest request, CancellationToken cancellationToken = default);

        Task ProcessCall(ProcessCallRequest request, CancellationToken cancellationToken = default);
    }
}
