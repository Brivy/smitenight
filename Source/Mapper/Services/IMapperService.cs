using Smitenight.Utilities.Mapper.Contracts.Contracts;

namespace Smitenight.Utilities.Mapper.Services
{
    public interface IMapperService
    {
        IMapper<TSource, TDestination> GetMapper<TSource, TDestination>();
        TDestination Map<TSource, TDestination>(TSource source);
        IEnumerable<TDestination> MapAll<TSource, TDestination>(IEnumerable<TSource> source);
        TDestination[] MapAll<TSource, TDestination>(TSource[] source);
    }
}