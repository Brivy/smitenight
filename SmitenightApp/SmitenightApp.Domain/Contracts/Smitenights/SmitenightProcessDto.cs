using System.ComponentModel.DataAnnotations;

namespace SmitenightApp.Domain.Contracts.Smitenights
{
    public record class SmitenightProcessDto
    {
        [Required]
        public string PlayerName { get; set; } = null!;

        public string? PinCode { get; set; }
    }
}
