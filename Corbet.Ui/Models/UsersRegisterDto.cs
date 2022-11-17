using Corbet.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Corbet.Ui.Models
{
    public class UsersRegisterDto : AuditableEntity
    {
        [DisplayName("User Id")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [MinLength(3, ErrorMessage ="First Name must at least 3 characters")]
        [MaxLength(20, ErrorMessage ="First Name must less than 20 characters")]
        [RegularExpression(@"^([a-zA-Z])*$", ErrorMessage = " First Name must contain only alphabet")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(3, ErrorMessage ="Last Name must at least 3 characters")]
        [MaxLength(20, ErrorMessage ="Last Name must less than 20 characters")]
        [RegularExpression(@"^([a-zA-Z])*$", ErrorMessage = " Last Name must contain only alphabet ")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$", ErrorMessage = "Please Enter A Valid Email Address")]
        [Remote("IsEmailExist", "UserRegister", HttpMethod = "GET", ErrorMessage = "Email Already Exist")]
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$", ErrorMessage = "Minimum eight characters, at least one upper case English letter, one lower case English letter, one number and one special character")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Re-Enter Password to confirm")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password are not same")]
        public string? ConfirmPassword { get; set; }

        //[MaxLength(10, ErrorMessage ="Enter valid Phone Number")]
        //[MinLength(10, ErrorMessage ="Enter valid Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[6-9]{1}[0-9]{9}$", ErrorMessage = "Please Enter A Valid Phone Number")]
        //[Remote("IsPhoneExist", "UserRegister", HttpMethod = "GET", ErrorMessage = "Phone Number Already Exist")]
        [DisplayName("Phone")]
        public string PhoneNumber { get; set; }
        public bool IsPhoneNumberConfirmed { get; set; } = false;
        public bool IsLocked { get; set; } = false;
        public bool IsTwoFactorEnabled { get; set; } = false;

        [Required(ErrorMessage = "Choose A Role")]
        [DisplayName("Role")]
        public int RoleId { get; set; }
        [DisplayName("Active Status")]
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
