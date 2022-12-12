using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class ResetPasswordViewModel
    {
        public string? UserId { get; set; }
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{4,20}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit & one special symbol.")]// Password must be more than 5 characters & less than 21 characters.")]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Both passwords should match")]
        public string ConfirmPassword { get; set; }
    }
}
