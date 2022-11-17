using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Users.Commands.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<Response<string>>
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        public ForgotPasswordCommand(string email)
        {
            Email = email;
        }
    }
}
