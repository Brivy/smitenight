using Smitenight.Utilities.Mapper.Common.Contracts;

namespace Smitenight.Utilities.Mapper.Common.Services
{
    public interface IMapperService
    {
        IMapper<TInput, TOutput> GetMapper<TInput, TOutput>();

        TOutput Map<TInput, TOutput>(TInput input);
    }
}