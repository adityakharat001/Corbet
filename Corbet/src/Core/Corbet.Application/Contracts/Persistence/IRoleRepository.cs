using Corbet.Application.Features.Roles.Commands.DeleteRole;
using Corbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IRoleRepository:IAsyncRepository<Role>
    {
        public Task<DeleteRoleCommandDto> RemoveRoleAsync(int roleId);
        public Task<List<Role>> GetAllRoles();
        public Task<bool> CheckRoleExists(string rolename);
    }
}
