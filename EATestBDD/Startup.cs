using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductAPI.Data;
using ProductAPI.Repository;
using SolidToken.SpecFlow.DependencyInjection;

namespace EATestBDD;

public static class Startup
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];

        IConfigurationRoot configuration = new ConfigurationBuilder()
                     .SetBasePath(projectPath)
                     .AddJsonFile("appsettings.json")
                     .Build();

        string connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ProductDbContext>(
                            option => option
                                      .UseSqlServer(connectionString));

        services.AddTransient<IProductRepository, ProductRepository>();
        services.UseWebDriverInitializer();
        services.AddScoped<IHomePage, HomePage>();
        services.AddScoped<IProductPage, ProductPage>();
        services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IBrowserDriver, BrowserDriver>();

        return services;
    }

}
