namespace Smitenight.Application.Blazor.Business.Services.Checksums
{
    public interface IChecksumService
    {
        string CalculateChecksum<T>(T @object);
        bool IsChecksumDifferent<TCompare>(string checksum, TCompare comparisonObject);
    }
}