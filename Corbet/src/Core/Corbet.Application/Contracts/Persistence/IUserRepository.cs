using Corbet.Application.Features.Users.Commands.CreateUser;
using Corbet.Application.Features.Users.Commands.DeleteUser;
using Corbet.Application.Features.Users.Queries.GetAllUsers;
using Corbet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        public Task<List<Role>> GetAllRole();
        public Task<User> GetUserByEmail(string email);
        public Task<User> FindUserByEmail(string email, string Password);
        public Task<CreateUserCommandDto> RegisterUserAsync(User user);
        public Task<bool> EmailVerified(User user);
        public Task<bool> CheckEmailExists(string email);
        public Task<bool> CheckPhoneExists(string phone);
        public Task<List<GetUsersQueryVm>> GetAllUsers();
        public Task<DeleteUserCommandDto> RemoveUserAsync(int userId, int? deletedBy);
    }
}
