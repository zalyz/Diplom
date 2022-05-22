using Ambulance.IdentityApi.Client.Resources.Account;

namespace Ambulance.IdentityApi.Client
{
    public interface IIdentityApiClient
    {
        IAccountResource AccountResource { get; }
    }

    public class IdentityApiClient : IIdentityApiClient
    {
        private readonly ResourceCreator _resourceCreator;

        public IdentityApiClient(string baseAddress, string tenant)
        {
            _resourceCreator = new ResourceCreator(baseAddress, tenant);
        }

        public IAccountResource AccountResource => _resourceCreator.CreateResource<IAccountEndpoint, AccountResource>();
    }
}
