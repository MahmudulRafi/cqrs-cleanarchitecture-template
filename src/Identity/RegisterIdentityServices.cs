using Application.Models.Common;
using Identity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Identity
{
    public static class RegisterIdentityServices
    {
        private const string JwtOptionsSectionName = "JWTOptions";
        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityDatabaseContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("AppDbConnection"));
            });

            services.AddIdentityApiEndpoints<ApplicationUser>()
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<IdentityDatabaseContext>()
                .AddDefaultTokenProviders();

            var jwtOptions = configuration.GetSection(JwtOptionsSectionName).Get<JwtOption>();

            if (IsInvalidJwt(jwtOptions))
                throw new InvalidOperationException("Invalid JWT configuration. Ensure that 'JWTOptions' section is properly configured in appsettings.");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),
                   ValidateIssuer = true,
                   ValidIssuer = jwtOptions.ValidIssuer,
                   ValidateAudience = true,
                   ValidAudience = jwtOptions.ValidAudience,
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.Zero
               };
           });

            return services;
        }

        private static bool IsInvalidJwt(JwtOption? jwtOptions)
        {
            return jwtOptions is null || string.IsNullOrWhiteSpace(jwtOptions.Secret) || string.IsNullOrWhiteSpace(jwtOptions.ValidIssuer) || string.IsNullOrWhiteSpace(jwtOptions.ValidAudience);
        }
    }
}
