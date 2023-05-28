using Smitenight.Utilities.Mapper.Common.Contracts;

namespace Smitenight.Utilities.Mapper.Common.Services
{
    public class MapperService : IMapperService
    {
        private readonly Dictionary<(Type, Type), IMapper> _mappers;

        public MapperService(IEnumerable<IMapper> mappers)
        {
            _mappers = mappers.ToDictionary(m => (m.InputType, m.OutputType));
        }

        public IMapper<TSource, TDestination> GetMapper<TSource, TDestination>()
        {
            if (_mappers.TryGetValue((typeof(TSource), typeof(TDestination)), out var mapper))
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

            var mapper = GetMapper<TSource, TDestination>();
            return mapper.Map(source);
        }

        public IEnumerable<TDestination> MapAll<TSource, TDestination>(IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var mappedItems = new List<TDestination>();
            foreach (var item in source)
            {
                mappedItems.Add(Map<TSource, TDestination>(item));
            }

            return mappedItems;
        }

        public IEnumerable<TDestination> MapAll<TSource, TDestination>(TSource[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var mappedItems = new List<TDestination>();
            foreach (var item in source)
            {
                mappedItems.Add(Map<TSource, TDestination>(item));
            }

            return mappedItems;
        }
    }
}
