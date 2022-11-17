using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQuery: IRequest<Role>
    {
        public int RoleId { get; set; }
    }
}
