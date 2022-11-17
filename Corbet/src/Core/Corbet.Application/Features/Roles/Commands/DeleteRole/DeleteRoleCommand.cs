using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommand: IRequest<Response<DeleteRoleCommandDto>>
    {
        public int RoleId { get; set; }
    }
}
