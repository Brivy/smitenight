using System.ComponentModel.DataAnnotations;

namespace Smitenight.Persistence.Data.EntityFramework.Secrets
{
    public record DatabaseSecrets
    {
        [Required]
        public required string ConnectionString { get; set; }
    }
}
