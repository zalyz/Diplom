using RestEase;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.ServiceAPI.Client.Resources.Doktors
{
    public interface IEmployeeEndpoint : IBaseContract
    {
        [Get("api/employee/doktors")]
        Task<HttpResponseMessage> GetDoktors(CancellationToken cancellationToken = default);

        [Get("api/employee/assistants")]
        Task<HttpResponseMessage> GetMedicalAssistants(CancellationToken cancellationToken = default);

        [Get("api/employee/ordirlies")]
        Task<HttpResponseMessage> GetOrderlies(CancellationToken cancellationToken = default);

        [Get("api/employee/drivers")]
        Task<HttpResponseMessage> GetDrivers(CancellationToken cancellationToken = default);
    }
}
