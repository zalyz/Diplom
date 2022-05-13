using Ambulance.Domain.Models.Patients;
using RestEase;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.CallApi.Client.Resources.Patients
{
    public interface IPatientEndpoint : IBaseContract
    {
        [Get("api/patient")]
        Task<HttpResponseMessage> GetPatient([Body] int id, CancellationToken cancellationToken = default);

        [Patch("api/patient")]
        Task<HttpResponseMessage> UpdatePatient([Body] UpdatePatienRequest request, CancellationToken cancellationToken = default);
    }
}
