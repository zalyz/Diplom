using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.IdentityApi.Client.Extensions
{
    public static class ClientDeserializer
    {
        public static async Task<T> Deserialize<T>(this HttpResponseMessage message, CancellationToken cancellationToken = default)
        {
            var stringContent = await message.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<T>(stringContent);
        }

        public static async Task<string> DeserializeToString(this HttpResponseMessage message, CancellationToken cancellationToken = default)
        {
            var stringContent = await message.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            return stringContent;
        }
    }
}
