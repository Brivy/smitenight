using System.ComponentModel.DataAnnotations;

namespace SmitenightApp.Domain.Contracts.Smitenights
{
    public record class SmitenightProcessRequestDto
    {
        [Required]
        public string PlayerName { get; set; } = null!;

        [Required]
        public string PassCode { get; set; } = null!;
    }
}
