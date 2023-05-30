using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Application.Blazor.Business.Extensions;
using Smitenight.Persistence.Data.EntityFramework.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Utilities.Cache.Redis.Extensions;
using Smitenight.Utilities.Cache.Redis.Secrets;
using Smitenight.Utilities.Mapper.Common.Extensions;

namespace Smitenight.Presentation.Test.Maintenance
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
               .AddUserSecrets<SmiteClientSecrets>()
               .AddUserSecrets<DatabaseSecrets>()
               .AddUserSecrets<RedisCacheSecrets>()
               .Build();

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.ConfigureCacheServices(configuration);
                    services.ConfigureMapperServices();
                    services.ConfigureBusinessServices(configuration);
                })
                .Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;
                var maintainSmitenight = serviceProvider.GetRequiredService<IMaintainSmitenight>();
                await maintainSmitenight.MaintainGodsAsync();
            }
        }
    }
}