using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.StatisticsApi.Client.Resources.Brigades
{
    public interface IBrigadeResource
    {
        Task<byte[]> GetBrigadeCalls(CancellationToken cancellationToken = default);
    }
}
