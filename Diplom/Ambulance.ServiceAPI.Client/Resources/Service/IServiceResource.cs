using Ambulance.Domain.Models.ServiceModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.ServiceAPI.Client.Resources.Service
{
    public interface IServiceResource
    {
        public Task<List<Caller>> GetCallers(CancellationToken cancellationToken = default);

        public Task<List<Diagnosis>> GetDiagnosis(CancellationToken cancellationToken = default);

        public Task<List<Street>> GetStreets(CancellationToken cancellationToken = default);
    }
}
