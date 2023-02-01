using EATestFramework.Driver;
using EATestFramework.Extensions;
using EATestProject.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace EATestProject;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.UseWebDriverInitializer();
        services.AddScoped<IHomePage, HomePage>();
        services.AddScoped<IProductPage, ProductPage>();
        services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IBrowserDriver, BrowserDriver>();
    }

}