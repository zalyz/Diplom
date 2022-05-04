using Ambulance.Domain.Models.ServiceModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.ServiceAPI.Client.Resources.Service
{
    internal class ServiceResource : ResourceBase<IServiceEndpoint>, IServiceResource
    {
        public ServiceResource(IServiceEndpoint apiClient, string tenant)
            : base(apiClient, tenant)
        {
        }

        public Task<List<Caller>> GetCallers(CancellationToken cancellationToken = default)
        {
            return Execute<List<Caller>>(token => Client.GetCallers(token), cancellationToken);
        }

        public Task<List<Diagnosis>> GetDiagnosis(CancellationToken cancellationToken = default)
        {
            return Execute<List<Diagnosis>>(token => Client.GetDiagnosis(token), cancellationToken);
        }

        public Task<List<Street>> GetStreets(CancellationToken cancellationToken = default)
        {
            return Execute<List<Street>>(token => Client.GetStreets(token), cancellationToken);
        }
    }
}
