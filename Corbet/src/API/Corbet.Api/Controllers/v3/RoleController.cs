using Corbet.Application.Features.Roles.Commands.CreateRole;
using Corbet.Application.Features.Roles.Commands.DeleteRole;
using Corbet.Application.Features.Roles.Commands.UpdateRole;
using Corbet.Application.Features.Roles.Queries.GetAllRoles;
using Corbet.Application.Features.Roles.Queries.GetRoleById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public RoleController(IMediator mediator, ILogger<RoleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<ActionResult> CreateRole(CreateRoleCommand createRoleCommand)
        {
            _logger.LogInformation("Add Role initiated");
            var response = await _mediator.Send(createRoleCommand);
            _logger.LogInformation("Add Role completed");
            return Ok(response);
        }

        [HttpGet]
        [Route("AllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            _logger.LogInformation("Roles list initiated");
            var roleList = await _mediator.Send(new GetRolesListQuery());
            _logger.LogInformation("Roles list completed");
            return Ok(roleList);
        }

        [HttpGet]
        [Route("GetRoleById")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            _logger.LogInformation("Get Role by Id initiated");
            var role = await _mediator.Send(new GetRoleByIdQuery() { RoleId = id});
            _logger.LogInformation("Get Role by Id completed");
            return Ok(role);
        }


        [HttpPost]
        [Route("UpdateRole")]
        public async Task<ActionResult> UpdateRole([FromBody] UpdateRoleCommand updateRoleCommand)
        {
            _logger.LogInformation("Update role initiated");
            var response = await _mediator.Send(updateRoleCommand);
            _logger.LogInformation("Upadte role completed");
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            _logger.LogInformation("Roles delete initiated");
            await _mediator.Send(new DeleteRoleCommand() { RoleId = id});
            _logger.LogInformation("Roles delete completed");
            return NoContent();
        }
    }
}
