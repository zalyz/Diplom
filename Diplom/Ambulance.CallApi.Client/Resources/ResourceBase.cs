using Ambulance.CallApi.Client.Extensions;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.CallApi.Client.Resources
{
    public class ResourceBase <T>
        where T : class, IBaseContract
    {
        public ResourceBase(T apiClient, string tenant)
        {
            Client = apiClient;
            Client.Tenant = tenant;
        }

        protected T Client { get; }

        protected async Task Execute(Func<CancellationToken, Task<HttpResponseMessage>> action, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using var operationResult = await action(cancellationToken).ConfigureAwait(false);
            if (!operationResult.IsSuccessStatusCode)
            {
                throw new Exception(operationResult.StatusCode.ToString());
            }
        }

        protected async Task<TResult> Execute<TResult>(Func<CancellationToken, Task<HttpResponseMessage>> action, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using var operationResult = await action(cancellationToken).ConfigureAwait(false);
            if (!operationResult.IsSuccessStatusCode)
            {
                throw new Exception(operationResult.StatusCode.ToString());
            }

            return await operationResult.Deserialize<TResult>(cancellationToken).ConfigureAwait(false);
        }
    }
}
