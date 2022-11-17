using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Response<DeleteUserCommandDto>>
    {
        public int UserId { get; set; }
    }
}
