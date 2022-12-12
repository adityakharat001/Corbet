using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Corbet.Domain.Common;

namespace Corbet.Ui.Models
{
    public class CustomerUpdateDto : AuditableEntityModel
    {
        public string Id { get; set; }
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [MinLength(3, ErrorMessage = "First Name must at least 3 characters")]
        [MaxLength(150, ErrorMessage = "First Name must less than 150 characters")]
        [RegularExpression(@"^([a-zA-Z])*$", ErrorMessage = "First Name must contain only alphabet")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(3, ErrorMessage = "Last Name must at least 3 characters")]
        [MaxLength(150, ErrorMessage = "Last Name must less than 150 characters")]
        [RegularExpression(@"^([a-zA-Z])*$", ErrorMessage = "Last Name must contain only alphabet ")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$", ErrorMessage = "Please Enter A Valid Email Address")]
        //[Remote("IsEmailExist", "UserRegister", HttpMethod = "GET", ErrorMessage = "Email Already Exist")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[6-9]{1}[0-9]{9}$", ErrorMessage = "Please Enter A Valid Phone Number")]
        //[Remote("IsPhoneExist", "UserRegister", HttpMethod = "GET", ErrorMessage = "Phone Number Already Exist")]
        [DisplayName("Phone")]
        public string? PhoneNumber { get; set; }
        
        public int State { get; set; }
        [Required(ErrorMessage = "City Name is required")]
        [RegularExpression(@"^([a-zA-Z])*$", ErrorMessage = "City Name must contain only alphabet ")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [DisplayName("Alternate Address")]
        public string? AlternateAddress { get; set; }
        public string? ImagePath { get; set; }
    }
}
