using Ambulance.DAL.CallAPI;
using Ambulance.DAL.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ServiceAPI.Middleware;
using System.Collections.Generic;

namespace ServiceAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISecretStorageService, SecretStorageService>();
            services.AddDbContext<ICallContext, CallContext>();
            services.AddScoped<IDatabaseProvider, DatabaseProvider>();
            services.AddMediatR(typeof(Startup).Assembly);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ServiceAPI", Version = "v1" });
                c.AddSecurityDefinition("Tenant", new OpenApiSecurityScheme
                {
                    Description = "Tenant name",
                    Name = "Tenant",
                    In = ParameterLocation.Query,
                    Type = SecuritySchemeType.ApiKey,
                });

                var tenant = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Tenant",
                    },
                };

                c.AddSecurityRequirement(new OpenApiSecurityRequirement { [tenant] = new List<string>() });
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ServiceAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<ConnectionStringMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
