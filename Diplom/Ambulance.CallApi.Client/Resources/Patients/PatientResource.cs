using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Patients;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.CallApi.Client.Resources.Patients
{
    public class PatientResource : ResourceBase<IPatientEndpoint>, IPatientResource
    {
        public PatientResource(IPatientEndpoint apiClient, string tenant)
            : base(apiClient, tenant)
        {
        }

        public Task<Patient> GetPatient(int id, CancellationToken cancellationToken = default)
        {
            return Execute<Patient>(token => Client.GetPatient(id, token), cancellationToken);
        }

        public Task UpdatePatient(UpdatePatienRequest request, CancellationToken cancellationToken = default)
        {
            return Execute(token => Client.UpdatePatient(request, cancellationToken));
        }
    }
}
