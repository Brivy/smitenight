using Smitenight.Application.Blazor.Business.Contracts.Services.Checksums;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Smitenight.Application.Blazor.Business.Services.Checksums
{
    public class ChecksumService : IChecksumService
    {
        public string CalculateChecksum<T>(T @object)
        {
            var json = JsonSerializer.Serialize(@object);
            var bytes = MD5.HashData(Encoding.UTF8.GetBytes(json));
            var builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public bool IsChecksumDifferent<TCompare>(string checksum, TCompare comparisonObject)
        {
            return checksum != CalculateChecksum(comparisonObject);
        }
    }
}
