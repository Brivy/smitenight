using Microsoft.Extensions.Options;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using System.Security.Cryptography;
using System.Text;

namespace Smitenight.Providers.SmiteProvider.HiRez.Services
{
    public class SmiteHashService : ISmiteHashService
    {
        private readonly SmiteClientSecrets _smiteClientSecrets;

        public SmiteHashService(IOptions<SmiteClientSecrets> smiteClientSecrets)
        {
            _smiteClientSecrets = smiteClientSecrets.Value;
        }

        public string GenerateSmiteHash(string methodName, string utcDateString)
        {
            var credentials = $"{_smiteClientSecrets.DeveloperId}{methodName}{_smiteClientSecrets.AuthenticationKey}{utcDateString}";

            using var md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.ASCII.GetBytes(credentials));
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("x2").ToLower());
            }

            return sb.ToString();
        }
    }
}
