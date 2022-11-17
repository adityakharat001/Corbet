using System.ComponentModel;

namespace Corbet.Ui.Models
{
    public class UserViewModel
    {
        [DisplayName("User Id")]
        public int UserId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Password { get; set; }
        [DisplayName("Phone")]
        public string? PhoneNumber { get; set; }
        public string Role { get; set; }
        [DisplayName("Active Status")]
        public bool IsActive { get; set; }
        [DisplayName("Deleted Status")]
        public bool IsDeleted { get; set; }
    }
}
