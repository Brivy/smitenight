using Microsoft.Extensions.DependencyInjection;
using Smitenight.Utilities.Mapper.Contracts.Contracts;
using Smitenight.Utilities.Mapper.Services;
using System.Reflection;

namespace Smitenight.Utilities.Mapper.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureMapperServices(this IServiceCollection services)
        {
            services.AddScoped<IMapperService, MapperService>();
            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services, Assembly assembly)
        {
            var mapperGenericType = typeof(IMapper<,>);
            var mapperType = typeof(IMapper);

            var mapperTypes = assembly.GetTypes()
                .Where(t => t.IsPublic && !t.IsAbstract && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == mapperGenericType));

            foreach (var type in mapperTypes)
            {
                var mapperInterface = type.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == mapperGenericType);

                services.AddScoped(mapperInterface, type);
                services.AddScoped(mapperType, type);
            }

            return services;
        }
    }
}
