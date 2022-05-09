using Ambulance.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.ServiceAPI.Client.Resources.Doktors
{
    public class EmployeeResource : ResourceBase<IEmployeeEndpoint>, IEmployeeResource
    {
        public EmployeeResource(IEmployeeEndpoint apiClient, string tenant)
            : base(apiClient, tenant)
        {
        }

        public Task<List<Doktor>> GetDoktorsAsync(CancellationToken cancellationToken = default)
        {
            return Execute<List<Doktor>>(token => Client.GetDoktors(token), cancellationToken);
        }

        public Task<List<Driver>> GetDrivers(CancellationToken cancellationToken = default)
        {
            return Execute<List<Driver>>(token => Client.GetDrivers(token), cancellationToken);
        }

        public Task<List<MedicalAssistant>> GetMedicalAssistants(CancellationToken cancellationToken = default)
        {
            return Execute<List<MedicalAssistant>>(token => Client.GetMedicalAssistants(token), cancellationToken);
        }

        public Task<List<Orderly>> GetOrderlies(CancellationToken cancellationToken = default)
        {
            return Execute<List<Orderly>>(token => Client.GetOrderlies(token), cancellationToken);
        }
    }
}
