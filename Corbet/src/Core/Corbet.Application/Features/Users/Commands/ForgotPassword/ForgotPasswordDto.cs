using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Users.Commands.ForgotPassword
{
    public class ForgotPasswordDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}
