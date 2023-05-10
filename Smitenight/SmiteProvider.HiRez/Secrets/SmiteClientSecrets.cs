using System.ComponentModel.DataAnnotations;

namespace Smitenight.Providers.SmiteProvider.HiRez.Secrets
{
    public class SmiteClientSecrets
    {
        [Required]
        public int DeveloperId { get; set; }

        [Required]
        public string AuthenticationKey { get; set; } = null!;
    }
}
