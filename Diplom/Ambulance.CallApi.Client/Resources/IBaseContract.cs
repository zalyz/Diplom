using RestEase;

namespace Ambulance.CallApi.Client.Resources
{
    public interface IBaseContract
    {
        [Query("tenant")]
        string Tenant { get; set; }
    }
}
