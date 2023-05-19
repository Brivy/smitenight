using Microsoft.Extensions.DependencyInjection;
using Smitenight.Utilities.Mapper.Common.Contracts;
using System.Reflection;

namespace Smitenight.Utilities.Mapper.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMappers(this IServiceCollection services, Assembly assembly)
        {
            var mapperType = typeof(IMapper<,>);
            var mapperTypes = assembly.GetTypes()
                .Where(t => t.IsPublic && !t.IsAbstract && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == mapperType));

            foreach (var type in mapperTypes)
            {
                var mapperInterface = type.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == mapperType);
                services.AddScoped(mapperInterface, type);
            }

            return services;
        }
    }

}
