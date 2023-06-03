using Smitenight.Utilities.Mapper.Contracts.Contracts;

namespace Smitenight.Utilities.Mapper.Models
{
    public abstract class Mapper<TInput, TOutput> : IMapper<TInput, TOutput>
    {
        public Type InputType => typeof(TInput);
        public Type OutputType => typeof(TOutput);

        public abstract TOutput Map(TInput input);
    }
}
