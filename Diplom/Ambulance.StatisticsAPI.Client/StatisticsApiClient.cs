using Ambulance.StatisticsApi.Client.Resources.Brigades;
using Ambulance.StatisticsApi.Client.Resources.Calls;

namespace Ambulance.StatisticsApi.Client
{
    public interface IStatisticsApiClient
    {
        public ICallResource CallResource { get; }

        public IBrigadeResource BrigadeResource { get; }
    }

    public class StatisticsApiClient : IStatisticsApiClient
    {
        private readonly ResourceCreator _resourceCreator;

        public StatisticsApiClient(string baseAddress, string tenant)
        {
            _resourceCreator = new ResourceCreator(baseAddress, tenant);
        }

        public ICallResource CallResource => _resourceCreator.CreateResource<ICallEndpoint, CallResource>();

        public IBrigadeResource BrigadeResource => _resourceCreator.CreateResource<IBrigadeEndpoint, BrigadeResource>();
    }
}
