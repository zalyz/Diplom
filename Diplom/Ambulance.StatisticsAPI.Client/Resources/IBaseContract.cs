using RestEase;

namespace Ambulance.StatisticsApi.Client.Resources
{
    public interface IBaseContract
    {
        [Query("tenant")]
        string Tenant { get; set; }
    }
}
