using Ambulance.DAL.CallAPI;
using Ambulance.DAL.Services;
using IdentityAPI.Middleware;
using IdentityAPI.Services;
using IdentityAPI.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityAPI
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
            var tokenSettings = Configuration.GetSection(nameof(JwtTokenSettings));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = tokenSettings[nameof(JwtTokenSettings.JwtIssuer)],
                        ValidateAudience = true,
                        ValidAudience = tokenSettings[nameof(JwtTokenSettings.JwtAudience)],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings[nameof(JwtTokenSettings.JwtSecretKey)])),
                        ValidateLifetime = false,
                    };
                });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "IdentityAPI", Version = "v1" });
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Description = "Jwt Token is required to access the endpoints",
                    In = ParameterLocation.Header,
                    Name = "JWT Authentication",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme,
                    },
                };

                options.AddSecurityDefinition("Tenant", new OpenApiSecurityScheme
                {
                    Description = "Tenant name",
                    Name = "Tenant",
                    In = ParameterLocation.Query,
                    Type = SecuritySchemeType.ApiKey,
                });
                options.AddSecurityDefinition("Bearer", jwtSecurityScheme);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() },
                });

                var tenant = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Tenant",
                    },
                };

                options.AddSecurityRequirement(new OpenApiSecurityRequirement { [tenant] = new List<string>() });
            });

            services.AddScoped<ISecretStorageService, SecretStorageService>();
            services.AddDbContext<ICallContext, Ambulance.DAL.CallAPI.CallContext>();
            services.AddScoped<IDatabaseProvider, DatabaseProvider>();

            services.Configure<JwtTokenSettings>(tokenSettings);
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddControllers();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdentityAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });

            app.UseAuthentication();
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
