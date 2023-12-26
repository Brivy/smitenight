using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smitenight.Application.Core.Business.Contracts.Services.Maintenance;
using Smitenight.Application.Core.Business.Extensions;
using Smitenight.Persistence.Data.EntityFramework.Extensions;
using Smitenight.Providers.SmiteProvider.HiRez.Extensions;
using Smitenight.Utilities.Cache.Redis.Extensions;
using Smitenight.Utilities.Mapper.Extensions;

namespace Smitenight.Presentation.Test.Maintenance;

public static class Program
{
    static async Task Main(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
           .ConfigureCacheSecrets()
           .ConfigureSmiteProviderSecrets()
           .ConfigureDataSecrets()
           .Build();

        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services
                    .AddSingleton(TimeProvider.System)
                    .ConfigureBusinessServices()
                    .ConfigureDataServices(configuration)
                    .ConfigureSmiteProviderServices(configuration)
                    .ConfigureMapperServices()
                    .ConfigureCacheServices(configuration);
            })
            .Build();

        using (IServiceScope serviceScope = host.Services.CreateScope())
        {
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;
            IMaintainSmitenight maintainSmitenight = serviceProvider.GetRequiredService<IMaintainSmitenight>();
            await maintainSmitenight.MaintainPatchesAsync();
            await maintainSmitenight.MaintainGodsAsync();
            await maintainSmitenight.MaintainItemsAsync();
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }
}
