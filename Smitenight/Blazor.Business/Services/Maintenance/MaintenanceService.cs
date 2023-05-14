using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Smitenight.Application.Blazor.Business.Services.Maintenance
{
    public class MaintenanceService : IMaintenanceService
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

    }
}
