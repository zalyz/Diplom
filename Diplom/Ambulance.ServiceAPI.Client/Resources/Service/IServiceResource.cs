using Ambulance.Domain.Models;
using Ambulance.Domain.Models.ServiceModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.ServiceAPI.Client.Resources.Service
{
    public interface IServiceResource
    {
        Task<List<Caller>> GetCallers(CancellationToken cancellationToken = default);

        Task<List<Diagnosis>> GetDiagnosis(CancellationToken cancellationToken = default);

        Task AddDiagnosis(AddDiagnosisRequest request, CancellationToken cancellationToken = default);

        Task<List<Street>> GetStreets(CancellationToken cancellationToken = default);

        Task AddStreet(AddStreetRequest request, CancellationToken cancellationToken = default);

        Task<List<Place>> GetPlaces(CancellationToken cancellationToken = default);

        Task<List<Result>> GetResults(CancellationToken cancellationToken = default);

        Task<List<Drug>> GetDrugs(CancellationToken cancellationToken = default);
    }
}
