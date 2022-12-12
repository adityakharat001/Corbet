using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Users.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest<Response<ResetPasswordDto>>
    {
        public string Email { get; set; }
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


