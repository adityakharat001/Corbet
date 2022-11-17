using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandDto
    {
        public string Message { get; set; }
        public string RoleName { get; set; }
        public bool Succeeded { get; set; }
    }
}
