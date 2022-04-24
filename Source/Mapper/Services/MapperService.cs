using Smitenight.Utilities.Mapper.Contracts.Contracts;

namespace Smitenight.Utilities.Mapper.Services;

public class MapperService(IEnumerable<IMapper> mappers) : IMapperService
{
    private readonly Dictionary<(Type, Type), IMapper> _mappers = mappers.ToDictionary(m => (m.InputType, m.OutputType));

    public IMapper<TSource, TDestination> GetMapper<TSource, TDestination>()
    {
        if (_mappers.TryGetValue((typeof(TSource), typeof(TDestination)), out IMapper? mapper))
        {
            return (IMapper<TSource, TDestination>)mapper;
        }

        throw new InvalidOperationException($"No mapper found for {typeof(TSource).Name} to {typeof(TDestination).Name}");
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        IMapper<TSource, TDestination> mapper = GetMapper<TSource, TDestination>();
        return mapper.Map(source);
    }

    public IEnumerable<TDestination> MapAll<TSource, TDestination>(IEnumerable<TSource> source)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var mappedItems = new List<TDestination>();
        foreach (TSource? item in source)
        {
            mappedItems.Add(Map<TSource, TDestination>(item));
        }

        return mappedItems;
    }

    public TDestination[] MapAll<TSource, TDestination>(TSource[] source)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var mappedItems = new TDestination[source.Length];
        for (int i = 0; i < source.Length; i++)
        {
            mappedItems[i] = Map<TSource, TDestination>(source[i]);
        }

        return mappedItems;
    }
}
