using RestEase;

namespace Ambulance.IdentityApi.Client.Resources
{
    public interface IBaseContract
    {
        [Query("tenant")]
        string Tenant { get; set; }
    }
}
