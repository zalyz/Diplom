using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Patients;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.CallApi.Client.Resources.Patients
{
    public interface IPatientResource
    {
        Task<Patient> GetPatient(int id, CancellationToken cancellationToken = default);

        Task UpdatePatient(UpdatePatienRequest request, CancellationToken cancellationToken = default);
    }
}
