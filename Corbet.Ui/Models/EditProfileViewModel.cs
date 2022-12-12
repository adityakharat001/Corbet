using Corbet.Application.Features.Customers.Commands.ChangePassword;

namespace Corbet.Ui.Models
{
    public class EditProfileViewModel
    {
        public CustomerUpdateDto customerUpdateDto { get; set; }
        public ChangePasswordCommand changePasswordCommand { get; set; }
    }
}
