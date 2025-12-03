using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestWindSystem.BLL;
using WestWindSystem.DAL;

namespace WestWindSystem;

public static class WestWindExtensions
{
    /// <summary>
    /// Registers EF Core (DbContextFactory) and BLL services for the WestWind system.
    /// </summary>
    public static IServiceCollection AddWestWindDependencies(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder> optionsAction)
    {
        // Register the EF Core context factory (Blazor Server safe).
        services.AddDbContextFactory<WestWindContext>(optionsAction);

        // Register BLL services explicitly
        services.AddTransient<CategoryServices>(sp =>
        {
            var dbContext = sp.GetRequiredService<IDbContextFactory<WestWindContext>>();
            return new CategoryServices(dbContext);
        });

        services.AddTransient<ProductServices>(sp =>
        {
            var dbContext = sp.GetRequiredService<IDbContextFactory<WestWindContext>>();
            return new ProductServices(dbContext);
        });

        services.AddTransient<RegionServices>(sp =>
        {
            var dbContext = sp.GetRequiredService<IDbContextFactory<WestWindContext>>();
            return new RegionServices(dbContext);
        });

        services.AddTransient<ShipmentServices>(sp =>
        {
            var dbContext = sp.GetRequiredService<IDbContextFactory<WestWindContext>>();
            return new ShipmentServices(dbContext);
        });

        services.AddTransient<ShipperServices>(sp =>
        {
            var dbContext = sp.GetRequiredService<IDbContextFactory<WestWindContext>>();
            return new ShipperServices(dbContext);
        });

        services.AddTransient<OrderServices>(sp =>
        {
            var dbContext = sp.GetRequiredService<IDbContextFactory<WestWindContext>>();
            return new OrderServices(dbContext);
        });

        services.AddTransient<SupplierServices>(sp =>
        {
            var dbContext = sp.GetRequiredService<IDbContextFactory<WestWindContext>>();
            return new SupplierServices(dbContext);
        });

        return services;
    }
}