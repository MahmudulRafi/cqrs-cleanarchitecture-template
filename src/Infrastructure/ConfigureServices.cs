using Domain.Repositories.Common;
using Infrastructure.Interceptors;
using Infrastructure.Repositories.Common;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((serviceProvider, option) => {
                
                var updateAuditableEntityInterceptor = serviceProvider.GetService<UpdateAuditableEntityInterceptor>()!;

                option.UseInMemoryDatabase("EventDB").AddInterceptors(updateAuditableEntityInterceptor);
            });

            using (var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();
            }

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
