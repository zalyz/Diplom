using Ambulance.CallApi.Client;
using Ambulance.IdentityApi.Client;
using Ambulance.ServiceAPI.Client;
using Ambulance.Web.Authorization;
using Ambulance.Web.Data;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ambulance.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var identityAddress = Configuration.GetSection("ApiAddresses").GetSection("IdentityApiAddress").Value;
            var callAddress = Configuration.GetSection("ApiAddresses").GetSection("CallApiAddress").Value;
            var serviceAddress = Configuration.GetSection("ApiAddresses").GetSection("ServiceApiAddress").Value;
            var tenantName = Configuration.GetSection("TenantName").Value;
            services.AddScoped<IIdentityApiClient>(e => new IdentityApiClient(identityAddress, tenantName));
            services.AddScoped<ICallApiClient>(e => new CallApiClient(callAddress, tenantName));
            services.AddScoped<IServiceApiClient>(e => new ServiceApiClient(serviceAddress, tenantName));

            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddBlazoredLocalStorage();
            services.AddOptions();
            

            services.AddScoped<IJwtAuthenticationStateProvider, JwtAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>().AddAuthorizationCore();
           // services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<JwtAuthenticationStateProvider>());

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
