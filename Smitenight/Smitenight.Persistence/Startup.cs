using Microsoft.Extensions.DependencyInjection;

namespace Smitenight.Persistence
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<SmitenightDbContext>();
        }
    }
}
