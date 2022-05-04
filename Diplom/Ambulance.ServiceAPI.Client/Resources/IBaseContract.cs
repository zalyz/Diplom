using RestEase;

namespace Ambulance.ServiceAPI.Client.Resources
{
    public interface IBaseContract
    {
        [Query("tenant")]
        string Tenant { get; set; }
    }
}
