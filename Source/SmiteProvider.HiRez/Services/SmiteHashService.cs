using Microsoft.Extensions.Options;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using System.Security.Cryptography;
using System.Text;

namespace Smitenight.Providers.SmiteProvider.HiRez.Services;

public class SmiteHashService(IOptions<SmiteClientSecrets> smiteClientSecrets) : ISmiteHashService
{
    private readonly SmiteClientSecrets _smiteClientSecrets = smiteClientSecrets.Value;

    public string GenerateSmiteHash(string methodName, string utcDateString)
    {
        string credentials = $"{_smiteClientSecrets.DeveloperId}{methodName}{_smiteClientSecrets.AuthenticationKey}{utcDateString}";
        byte[] bytes = MD5.HashData(Encoding.ASCII.GetBytes(credentials));
        var sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            sb.Append(b.ToString("x2").ToLower());
        }

        return sb.ToString();
    }
}
