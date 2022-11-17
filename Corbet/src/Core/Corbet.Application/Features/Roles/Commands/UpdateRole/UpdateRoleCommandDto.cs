    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
