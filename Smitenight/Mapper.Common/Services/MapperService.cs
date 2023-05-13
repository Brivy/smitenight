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

        public IMapper<TInput, TOutput> GetMapper<TInput, TOutput>()
        {
            if (_mappers.TryGetValue((typeof(TInput), typeof(TOutput)), out var mapper))
            {
                return (IMapper<TInput, TOutput>)mapper;
            }

            throw new InvalidOperationException($"No mapper found for {typeof(TInput).Name} to {typeof(TOutput).Name}");
        }

        public TOutput Map<TInput, TOutput>(TInput input)
        {
            var mapper = GetMapper<TInput, TOutput>();
            return mapper.Map(input);
        }
    }
}
