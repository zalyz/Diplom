using Ambulance.Domain.Models.Statistics;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.StatisticsApi.Client.Resources.Calls
{
    public interface ICallResource
    {
        Task<byte[]> GetDiagnosisGenderCalls(CancellationToken cancellationToken = default);

        Task<List<CallFullInfo>> GetCalls(CancellationToken cancellationToken = default);

        Task<byte[]> GetAgeDiagnosis(CancellationToken cancellationToken = default);
    }
}
