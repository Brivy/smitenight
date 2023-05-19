using System.ComponentModel.DataAnnotations;

namespace Smitenight.Providers.SmiteProvider.HiRez.Settings
{
    public class SmiteClientSettings
    {
        [Required]
        public string Url { get; set; } = null!;
    }
}
