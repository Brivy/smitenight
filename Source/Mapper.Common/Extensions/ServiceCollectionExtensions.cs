using Microsoft.Extensions.DependencyInjection;
using Smitenight.Utilities.Mapper.Common.Contracts;
using Smitenight.Utilities.Mapper.Common.Services;
using System.Reflection;

namespace Smitenight.Utilities.Mapper.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureMapperServices(this IServiceCollection services)
        {
            services.AddScoped<IMapperService, MapperService>();
        }

        public static IServiceCollection AddMappers(this IServiceCollection services, Assembly assembly)
        {
            var mapperGenericType = typeof(IMapper<,>);
            var mapperType = typeof(IMapper);

            var mapperTypes = assembly.GetTypes()
                .Where(t => t.IsPublic && !t.IsAbstract && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == mapperGenericType));

            foreach (var type in mapperTypes)
            {
                services.AddScoped(mapperType, type);
            }

            return services;
        }
    }

}
