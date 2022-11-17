using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Users.Commands.CreateUser;
using Corbet.Application.Features.Users.Commands.DeleteUser;
using Corbet.Application.Features.Users.Queries.GetAllUsers;
using Corbet.Domain.Entities;
using Corbet.Infrastructure.EncryptDecrypt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Corbet.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserRepository(ApplicationDbContext dbContext, ILogger<User> logger, IMapper mapper) : base(dbContext, logger)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public Task<bool> CheckEmailExists(string Email)
        {
            User check = _dbContext.Users.Where(x => x.Email == Email).FirstOrDefault();
            if (check != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
        
        public Task<bool> CheckPhoneExists(string Phone)
        {
            User check = _dbContext.Users.Where(x => x.PhoneNumber == Phone).FirstOrDefault();
            if (check != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public async Task<List<Role>> GetAllRole()
        {
            List<Role> role = _dbContext.Roles.Where(r => r.RoleName.ToLower() != "admin").ToList();
            return (role);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User user = _dbContext.Users.Where(u => u.Email == email).FirstOrDefault();
            return user;
        }

        public async Task<DeleteUserCommandDto> RemoveUserAsync(int UserId)
        {
            _logger.LogInformation("In Repository Remove User Initiated");
            DeleteUserCommandDto response = new DeleteUserCommandDto();
            var IsUserExist = await _dbContext.Users.Where(x => x.UserId == UserId).FirstOrDefaultAsync();
            if (IsUserExist != null)
            {

                IsUserExist.IsDeleted = true;
                IsUserExist.IsActive = false;
                await _dbContext.SaveChangesAsync();

                response.Email = IsUserExist.Email;
                response.FirstName = IsUserExist.FirstName;
                response.Message = "User Deleted Successful";
                response.Succeeded = true;
                return response;
                _logger.LogInformation("In Repository Remove User Completed");
            }

            else
            {
                response.Email = null;
                response.FirstName = null;
                response.Message = "User with this Id doesn't Exist";
                response.Succeeded = false;
                return response;
                _logger.LogInformation("In Repository Remove User Doesn't exist");
            }

        }

        public async Task<User> FindUserByEmail(string email, string password)
        {
            string encPassword = EncryptionDecryption.EncryptString(password);
            //string passwordData = password + Crypto.GenerateSalt();
            ////add hash password to above string 
            //string hashPassword = Crypto.HashPassword(passwordData);
            //string hashPasswordString = hashPassword.ToString();
            User user = await _dbContext.Users.Where(u => u.Email == email && u.Password == encPassword).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            else
            {
                if (!user.IsDeleted && user.IsActive)
                {
                    return user;
                }
                return null;
            }

        }


        public async Task<CreateUserCommandDto> RegisterUserAsync(User request)
        {
            var user = _dbContext.Users.Where(u => u.Email == request.Email).FirstOrDefault();
            CreateUserCommandDto response = new CreateUserCommandDto();
            if (user != null)
            {
                response.Message = "Email id Already Exist.";
                response.Succeeded = false;
                return response;

            }
            await _dbContext.Users.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            response.Email = request.Email;
            response.FirstName = request.FirstName;
            response.LastName = request.LastName;
            response.Password = request.Password;
            response.PhoneNumber = request.PhoneNumber;
            response.Role = request.RoleId;
            response.Succeeded = true;
            response.Message = "User registered successfully.";
            return response;
        }

        public async Task<bool> EmailVerified(User request)
        {
            request.IsEmailConfirmed = true;
            _applicationDbContext.Users.Update(request);
            int value = _applicationDbContext.SaveChanges();
            if (value > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<GetUsersQueryVm>> GetAllUsers()
        {

            var userdata = (from r in _dbContext.Roles
                          join u in _dbContext.Users
                          on r.RoleId equals u.RoleId
                          where u.IsDeleted == false
                          select new GetUsersQueryVm
                          {
                              UserId = u.UserId,
                              FirstName = u.FirstName,
                              LastName = u.LastName,
                              Email = u.Email,
                              Role = r.RoleName,
                              PhoneNumber = u.PhoneNumber,
                              IsActive = u.IsActive,
                              IsDeleted = u.IsDeleted

                          }).ToList();

            return userdata;
        }
    }
}
