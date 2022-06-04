using Ambulance.Domain.Models.Statistics;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.StatisticsApi.Client.Resources.Calls
{
    public class CallResource : ResourceBase<ICallEndpoint>, ICallResource
    {
        public CallResource(ICallEndpoint apiClient, string tenant)
            : base(apiClient, tenant)
        {
        }

        public Task<byte[]> GetAgeDiagnosis(CancellationToken cancellationToken = default)
        {
            return GetBytes(token => Client.GetAgeDiagnosis(token), cancellationToken);
        }

        public Task<List<CallFullInfo>> GetCalls(CancellationToken cancellationToken = default)
        {
            return Execute<List<CallFullInfo>>(token => Client.GetCalls(token), cancellationToken);
        }

        public Task<byte[]> GetDiagnosisGenderCalls(CancellationToken cancellationToken = default)
        {
            return GetBytes(token => Client.GetDiagnosisGenderCalls(token), cancellationToken);
        }
    }
}
