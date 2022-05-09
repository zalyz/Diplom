using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Brigade;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.CallApi.Client.Resources.Brigades
{
    public interface IBrigadeResource
    {
        Task<AmbulanceBrigade> GetBrigade(int brigadeId, CancellationToken cancellationToken = default);

        Task<List<AmbulanceBrigade>> GetBrigades(CancellationToken cancellationToken = default);

        Task<List<BrigadeMonitoringInfo>> GetBrigadesMonitoringInfo(CancellationToken cancellationToken = default);

        Task<List<CallOfficeInfo>> GetCalls(int brigadeId, CancellationToken cancellationToken = default);

        Task<int> CreateBrigade(CreateBrigadeRequest request, CancellationToken cancellationToken = default);

        Task RemoveBrigade(DeleteBrigadeRequest request, CancellationToken cancellationToken = default);

        Task AssignCallToBrigade(AssignCallRequest request, CancellationToken cancellationToken = default);

        Task ReleaseBrigade(int brigadeId, CancellationToken cancellationToken = default);

        Task ReturnCall(int brigadeId, CancellationToken cancellationToken = default);
    }
}
