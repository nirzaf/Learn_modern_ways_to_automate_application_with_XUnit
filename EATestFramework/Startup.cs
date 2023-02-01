using EATestFramework.Driver;
using EATestFramework.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace EATestFramework;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IBrowserDriver, BrowserDriver>();
    }

}