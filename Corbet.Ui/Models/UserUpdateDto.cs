using Corbet.Domain.Common;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class UserUpdateDto : AuditableEntityModel
    {
        public string Id { get; set; }
        [DisplayName("User Id")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "First Name Is required")]
        [RegularExpression(@"^([a-zA-Z])*$", ErrorMessage = " First Name must contain only alphabet ")]
        [MinLength(3, ErrorMessage = "First Name must at least 3 characters")]
        [MaxLength(20, ErrorMessage = "First Name must less than 20 characters")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Is required")]
        [RegularExpression(@"^([a-zA-Z])*$", ErrorMessage = " Last Name must contain only alphabet ")]
        [MinLength(3, ErrorMessage = "Last Name must at least 3 characters")]
        [MaxLength(20, ErrorMessage = "Last Name must less than 20 characters")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$", ErrorMessage = "Please Enter A Valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [DisplayName("Phone")]
        [RegularExpression(@"^[6-9]{1}[0-9]{9}$", ErrorMessage = "Please Enter A Valid Phone Number")]
        public string? PhoneNumber { get; set; }
    }
}
