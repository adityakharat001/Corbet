using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommand:IRequest<Response<UpdateRoleCommandDto>>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
