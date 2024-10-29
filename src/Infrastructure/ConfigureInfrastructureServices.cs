using Application.DTOs.Options;
using Domain.Abstractions.Common;
using Infrastructure.Data;
using Infrastructure.Identity.Models;
using Infrastructure.Repositories.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
    public static class ConfigureInfrastructureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((serviceProvider, option) =>
            {
                option.UseSqlServer(configuration.GetConnectionString("AppDbConnection"));
            });

            services.AddIdentityApiEndpoints<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            var jwtOptions = configuration.GetSection("JWTOptions").Get<JwtOption>();

            if (jwtOptions == null || string.IsNullOrWhiteSpace(jwtOptions.Secret) || string.IsNullOrWhiteSpace(jwtOptions.ValidIssuer) || string.IsNullOrWhiteSpace(jwtOptions.ValidAudience))
            {
                throw new InvalidOperationException("Invalid JWT configuration. Ensure that 'JWTOptions' section is properly configured in appsettings.");
            }

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = jwtOptions.ValidIssuer,
                   ValidAudience = jwtOptions.ValidAudience,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret))
               };
           });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
