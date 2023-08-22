using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration config)
    {
        var connectionString = config["DbConnection"];
        services.AddDbContext<GitRequestDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        services.AddScoped<IGitRequestDbContext>(provider =>
            provider.GetService<GitRequestDbContext>());
        return services;
    }
}
