using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Brigade;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.CallApi.Client.Resources.Brigades
{
    public class BrigadeResource : ResourceBase<IBrigadeEndpoint>, IBrigadeResource
    {
        public BrigadeResource(IBrigadeEndpoint apiClient, string tenant)
            : base(apiClient, tenant)
        {
        }

        public async Task AssignCallToBrigade(AssignCallRequest request, CancellationToken cancellationToken = default)
        {
            await Execute(token => Client.AssignCallToBrigade(request, token), cancellationToken);
        }

        public Task<int> CreateBrigade(CreateBrigadeRequest request, CancellationToken cancellationToken = default)
        {
            return Execute<int>(token => Client.CreateBrigade(request, token), cancellationToken);
        }

        public Task<List<AmbulanceBrigade>> GetBrigades(CancellationToken cancellationToken = default)
        {
            return Execute<List<AmbulanceBrigade>>(token => Client.GetBrigades(token), cancellationToken);
        }

        public async Task ReleaseBrigade(int brigadeId, CancellationToken cancellationToken = default)
        {
            await Execute(token => Client.ReleaseBrigade(brigadeId, token), cancellationToken);
        }

        public async Task RemoveBrigade(int brigadeId, CancellationToken cancellationToken = default)
        {
            await Execute(token => Client.RemoveBrigade(brigadeId, token), cancellationToken);
        }

        public async Task ReturnCall(int brigadeId, CancellationToken cancellationToken = default)
        {
            await Execute(token => Client.ReleaseBrigade(brigadeId, token), cancellationToken);
        }
    }
}
