using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Users.Commands.UserEmailExist
{
    public class UserEmailExistCommand : IRequest<bool>
    {
        public string Email { get; set; }
    }
}
