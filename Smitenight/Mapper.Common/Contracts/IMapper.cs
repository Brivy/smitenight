namespace Smitenight.Utilities.Mapper.Common.Contracts
{
    public interface IMapper
    {
        Type InputType { get; }
        Type OutputType { get; }
    }

    public interface IMapper<in TInput, out TOutput> : IMapper
    {
        TOutput Map(TInput input);
    }
}
