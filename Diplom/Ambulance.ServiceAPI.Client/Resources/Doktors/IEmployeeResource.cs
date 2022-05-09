using Ambulance.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.ServiceAPI.Client.Resources.Doktors
{
    public interface IEmployeeResource
    {
        Task<List<Doktor>> GetDoktorsAsync(CancellationToken cancellationToken = default);

        Task<List<MedicalAssistant>> GetMedicalAssistants(CancellationToken cancellationToken = default);

        Task<List<Orderly>> GetOrderlies(CancellationToken cancellationToken = default);

        Task<List<Driver>> GetDrivers(CancellationToken cancellationToken = default);
    }
}
