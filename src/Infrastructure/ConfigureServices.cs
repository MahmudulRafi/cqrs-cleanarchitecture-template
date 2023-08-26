namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("EventDB"));
            return services;
        }
    }
}
