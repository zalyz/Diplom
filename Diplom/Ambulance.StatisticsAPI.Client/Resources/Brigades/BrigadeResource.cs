using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.StatisticsApi.Client.Resources.Brigades
{
    public class BrigadeResource : ResourceBase<IBrigadeEndpoint>, IBrigadeResource
    {
        public BrigadeResource(IBrigadeEndpoint apiClient, string tenant)
            : base(apiClient, tenant)
        {
        }

        public Task<byte[]> GetBrigadeCalls(CancellationToken cancellationToken = default)
        {
            return GetBytes(token => Client.GetBrigadeCalls(token), cancellationToken);
        }
    }
}
