using Ambulance.CallApi.Client;
using Ambulance.IdentityApi.Client;
using Ambulance.ServiceAPI.Client;
using Ambulance.WebClient.Authorization;
using Ambulance.WebClient;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var identityAddress = builder.Configuration.GetSection("ApiAddresses").GetSection("IdentityApiAddress").Value;
var callAddress = builder.Configuration.GetSection("ApiAddresses").GetSection("CallApiAddress").Value;
var serviceAddress = builder.Configuration.GetSection("ApiAddresses").GetSection("ServiceApiAddress").Value;
var tenantName = builder.Configuration.GetSection("TenantName").Value;
builder.Services.AddScoped<IIdentityApiClient>(e => new IdentityApiClient(identityAddress, tenantName));
builder.Services.AddScoped<ICallApiClient>(e => new CallApiClient(callAddress, tenantName));
builder.Services.AddScoped<IServiceApiClient>(e => new ServiceApiClient(serviceAddress, tenantName));
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddScoped<IJwtAuthenticationStateProvider, JwtAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>().AddAuthorizationCore();

await builder.Build().RunAsync();
