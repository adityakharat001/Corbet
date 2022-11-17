using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Users.Commands.CreateUser;
using Corbet.Application.Features.Users.Commands.DeleteUser;
using Corbet.Application.Features.Users.Commands.UpdateUser;
using Corbet.Application.Features.Users.Commands.UserEmailExist;
using Corbet.Application.Features.Users.Queries.GetAllUsers;
using Corbet.Application.Features.Users.Queries.GetUserByEmail;
using Corbet.Application.Features.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ILogger<UserController> _logger;
        readonly IUserRepository _userRepository;

        public UserController(IMediator mediator, ILogger<UserController> logger, IUserRepository userRepository)
        {
            _mediator = mediator;
            _logger = logger;
            _userRepository = userRepository;
        }

        //@author:Rinku

      
        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult> CreateUser(CreateUserCommand user)
        {
            _logger.LogInformation("User add initiated");
            var addUser = await _mediator.Send(user);
            _logger.LogInformation("User added");
            return Ok(addUser);
        }


        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult> GetAllUsersWithRoles()
        {
            _logger.LogInformation("Get Users Initiated");
            var users = await _mediator.Send(new GetAllUsersQuery());
            _logger.LogInformation("Get Users Completed");
            return Ok(users);
        }


        [HttpGet]
        [Route("GetUserByEmail")]
        public async Task<ActionResult> GetUserByEmail(string email)
        {
            _logger.LogInformation("Get Users Initiated");
            var users = await _mediator.Send(new GetUserByEmailQuery() { Email = email});
            _logger.LogInformation("Get Users Completed");
            return Ok(users);
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<ActionResult> GetUserById(int id)
        {
            _logger.LogInformation("Get User Initiated");
            var user = await _mediator.Send(new GetUserByIdQuery() { UserId = id});
            _logger.LogInformation("Get User Completed");
            return Ok(user);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
        {
            _logger.LogInformation("Update User Initiated");
            var response = await _mediator.Send(updateUserCommand);
            _logger.LogInformation("Update User Completed");
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllRolesOfUser")]
        public async Task<ActionResult> GetAllRoles()
        {
            var roles = await _userRepository.GetAllRole();
            return Ok(roles);
        }

        [HttpPost]
        [Route("UserEmailExist")]
        public async Task<ActionResult> UserEmailExist(UserEmailExistCommand userEmailExist)
        {
            var emailExist = await _mediator.Send(userEmailExist);
            return Ok(emailExist);

        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult> DeleteUser(int Id)
        {
            _logger.LogInformation("Remove User Initiated");
            var dtos = await _mediator.Send(new DeleteUserCommand() { UserId = Id});
            _logger.LogInformation("Remove User Completed");
            return Ok(dtos);
        }
    }
}
