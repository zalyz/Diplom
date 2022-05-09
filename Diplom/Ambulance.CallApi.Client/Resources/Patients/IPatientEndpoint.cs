using Ambulance.Domain.Models.Patients;
using RestEase;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.CallApi.Client.Resources.Patients
{
    public interface IPatientEndpoint : IBaseContract
    {
        [Get]
        Task<HttpResponseMessage> GetPatient([Body] int id, CancellationToken cancellationToken = default);

        [Patch]
        Task<HttpResponseMessage> UpdatePatient([Body] UpdatePatienRequest request, CancellationToken cancellationToken = default);
    }
}
