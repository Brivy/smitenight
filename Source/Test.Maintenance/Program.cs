using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Application.Blazor.Business.Extensions;
using Smitenight.Persistence.Data.EntityFramework.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Utilities.Cache.Redis.Extensions;
using Smitenight.Utilities.Cache.Redis.Secrets;
using Smitenight.Utilities.Mapper.Extensions;

namespace Smitenight.Presentation.Test.Maintenance
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
               .AddUserSecrets<SmiteClientSecrets>()
               .AddUserSecrets<DatabaseSecrets>()
               .AddUserSecrets<RedisSecrets>()
               .Build();

            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton(TimeProvider.System);
                    services.ConfigureCacheServices(configuration);
                    services.ConfigureMapperServices();
                    services.ConfigureBusinessServices(configuration);
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
}
