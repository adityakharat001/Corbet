using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandDto
    {
        public string Message { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public bool Succeeded { get; set; }
    }
}
