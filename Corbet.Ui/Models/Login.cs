using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter an Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"^[a-zA-z0-9@&*$]{8,}", ErrorMessage = "Please enter a valid password")]
        // [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
