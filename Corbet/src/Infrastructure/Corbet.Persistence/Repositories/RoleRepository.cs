using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Roles.Commands.DeleteRole;
using Corbet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Persistence.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public RoleRepository(ApplicationDbContext dbContext, ILogger<Role> logger,IMapper mapper) : base(dbContext, logger)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            List<Role> roles = _dbContext.Roles.Where(r => r.IsDeleted == false).ToList();
            return (roles);
        }

        public async Task<DeleteRoleCommandDto> RemoveRoleAsync(int RoleId)
        {
            _logger.LogInformation("In Repository Remove User Initiated");
            DeleteRoleCommandDto response = new DeleteRoleCommandDto();
            var IsUserExist = await _dbContext.Roles.Where(x => x.RoleId == RoleId).FirstOrDefaultAsync();
            if (IsUserExist != null)
            {

                IsUserExist.IsDeleted = true;
                await _dbContext.SaveChangesAsync();

                response.RoleName = IsUserExist.RoleName;
                response.Message = "Role Deleted Successful";
                response.Succeeded = true;
                return response;
                _logger.LogInformation("In Repository Remove Role Completed");
            }

            else
            {
                response.RoleName = null;
                response.Message = "Role with this Id doesn't Exist";
                response.Succeeded = false;
                return response;
                _logger.LogInformation("In Repository Remove Role Doesn't exist");
            }
        }

        public Task<bool> CheckRoleExists(string RoleName)
        {
            Role check = _dbContext.Roles.Where(x => x.RoleName == RoleName).FirstOrDefault();
            if (check != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
