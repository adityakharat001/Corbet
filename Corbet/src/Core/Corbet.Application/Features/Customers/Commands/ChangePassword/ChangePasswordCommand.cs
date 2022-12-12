using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Responses;

using MediatR;

namespace Corbet.Application.Features.Customers.Commands.ChangePassword
{
    public class ChangePasswordCommand: IRequest<Response<ChangePasswordDto>>
    {
        public int CustomerId { get; set; }
        [Required]
        [DisplayName("Current Password")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{4,20}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit & one special symbol.")]// Password must be more than 5 characters & less than 21 characters.")]
        [StringLength(20, MinimumLength = 6)]
        public string OldPassword { get; set; }
        [Required]
        [DisplayName("New Password")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{4,20}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit & one special symbol.")]// Password must be more than 5 characters & less than 21 characters.")]
        [StringLength(20, MinimumLength = 6)]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Both passwords should match")]
        public string ConfirmPassword { get; set; }
    }
}
