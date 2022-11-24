using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Corbet.Application.Features.Roles.Queries.RoleNameExist
{
    public class RoleNameExistQuery : IRequest<bool>
    {
        public string RoleName { get; set; }
        public RoleNameExistQuery(string roleName)
        {
            RoleName = roleName;
        }
    }

}
