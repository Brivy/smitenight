using System.ComponentModel.DataAnnotations;

namespace SmitenightApp.Client.Forms.Smitenights
{
    public record class SmitenightProcessModel
    {
        [Required(ErrorMessage = "How can we track you without a playername :)")]
        public string PlayerName { get; set; } = null!;
        
        [Required(ErrorMessage = "We need verification that it is you who started/stopped the SMITE night")]
        [StringLength(4, ErrorMessage = "PIN should be 4 characters", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string PinCode { get; set; } = null!;
    }
}
