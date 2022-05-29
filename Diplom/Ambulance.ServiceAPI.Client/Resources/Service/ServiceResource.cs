using Ambulance.Domain.Models;
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

        public async Task AddDiagnosis(AddDiagnosisRequest request, CancellationToken cancellationToken = default)
        {
            await Execute(token => Client.AddDiagnosis(request, token), cancellationToken);
        }

        public async Task AddStreet(AddStreetRequest request, CancellationToken cancellationToken = default)
        {
            await Execute(token => Client.AddStreet(request, token), cancellationToken);
        }

        public Task<List<Caller>> GetCallers(CancellationToken cancellationToken = default)
        {
            return Execute<List<Caller>>(token => Client.GetCallers(token), cancellationToken);
        }

        public Task<List<Diagnosis>> GetDiagnosis(CancellationToken cancellationToken = default)
        {
            return Execute<List<Diagnosis>>(token => Client.GetDiagnosis(token), cancellationToken);
        }

        public Task<List<Drug>> GetDrugs(CancellationToken cancellationToken = default)
        {
            return Execute<List<Drug>>(token => Client.GetDrugs(token), cancellationToken);
        }

        public Task<List<Place>> GetPlaces(CancellationToken cancellationToken = default)
        {
            return Execute<List<Place>>(token => Client.GetPlaces(token), cancellationToken);
        }

        public Task<List<Result>> GetResults(CancellationToken cancellationToken = default)
        {
            return Execute<List<Result>>(token => Client.GetResults(token), cancellationToken);
        }

        public Task<List<Street>> GetStreets(CancellationToken cancellationToken = default)
        {
            return Execute<List<Street>>(token => Client.GetStreets(token), cancellationToken);
        }
    }
}
