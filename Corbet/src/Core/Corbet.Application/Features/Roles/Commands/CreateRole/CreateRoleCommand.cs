using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommand:IRequest<Response<CreateRoleDto>>
    {
        public string RoleName { get; set; }
    }
}
