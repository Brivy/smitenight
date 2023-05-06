using System.ComponentModel.DataAnnotations;

namespace Smitenight.Presentation.Blazor.Client.Forms.Smitenights
{
    public record class SmitenightProcessModel
    {
        [Required(ErrorMessage = "How can we track you without a playername :)")]
        public string PlayerName { get; set; } = null!;

        public bool PinCodeCheck { get; set; }

        [MaxLength(4, ErrorMessage = "PIN code should be 4 characters or less")]
        [DataType(DataType.Password)]
        public string PinCode { get; set; } = null!;
    }
}
