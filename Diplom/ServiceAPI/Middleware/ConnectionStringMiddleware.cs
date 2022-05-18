using Ambulance.DAL.Services;
using Ambulance.DAL.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace ServiceAPI.Middleware
{
    public class ConnectionStringMiddleware
    {
        private readonly RequestDelegate _next;

        public ConnectionStringMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ISecretStorageService secretStorage, IOptionsSnapshot<ConnectionSetting> options)
        {
            if(!context.Request.Query.TryGetValue("tenant", out var tenant) || string.IsNullOrEmpty(tenant))
            {
                return;
            }

            var connectionString = await secretStorage.GetConnectionString(tenant);
            options.Value.ConnectionString = connectionString;
            await _next.Invoke(context);
        }
    }
}
