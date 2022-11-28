using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Users.Commands.CheckPhoneExist;
using Corbet.Application.Features.Users.Commands.ForgotPassword;
using Corbet.Application.Features.Users.Commands.ResetPassword;
using Corbet.Application.Helper;
using Corbet.Application.Models.Authentication;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Corbet.Api.Controllers.v3
{

    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthenticationServiceLogin _authService;
        private readonly IConfiguration _configuration;
        private static bool flagToSendMail = true;
        private static StringBuilder oldValueEmail = new StringBuilder("");

        public AuthController(IAuthenticationServiceLogin authService, IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> LoginUser(LoginUserViewModel model)
        {
            try
            {
                AuthenticationResponse response = await _authService.Login(model.Email, model.Password);
                if (response != null)
                {
                    return Ok(response);
                }
                return BadRequest(new AuthenticationResponse() { Message = "Failed to Login user", IsAuthenticated = false, Token = null }); ;

            }
            catch (Exception e)
            {
                return BadRequest(new AuthenticationResponse() { Message = e.Message, IsAuthenticated = false, Token = null });
            }

        }


        [Route("ForgotPassword")]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var response = await _mediator.Send(new ForgotPasswordCommand(email));

            if (response.Succeeded)
            {
                if (!oldValueEmail.Equals(email))
                {
                    flagToSendMail = true;
                    oldValueEmail.Clear();
                }
                if (flagToSendMail is true)
                {
                    using (EmailManager emailManager = new EmailManager(_configuration))
                    {
                        emailManager.SendEmail(response.Data);
                    }
                    oldValueEmail.Append(email)
;
                    flagToSendMail = false;
                    return Ok(response);
                }
                else
                {
                    return BadRequest(new Response<string>() { Data = email, Succeeded = false, Errors = new List<string>() { "Email Already Sent!", "Multiple emails cannot be sent." } });
                }
            }
            else
            {
                return NotFound(response);
            }
        }

        [Route("ResetPassword")]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand resetPasswordCommand)
        {
            var response = await _mediator.Send(resetPasswordCommand);
            return (response.Succeeded) ? Ok(response) : BadRequest(response);
        }

        // Can be Remote validation
        [Route("DoesEmailExists/{email}")]
        [HttpGet]
        public async Task<IActionResult> DoesEmailAlreadyExists(string email)
        {
            var response = await _mediator.Send(new ForgotPasswordCommand(email));
            return (response.Succeeded) ? Ok(true) : Conflict(false);
        }
        
        [Route("DoesPhoneExists/{phone}")]
        [HttpGet]
        public async Task<IActionResult> DoesPhoneAlreadyExists(string phone)
        {
            var response = await _mediator.Send(new CheckPhoneExistCommand(phone));
            return (response) ? Ok(true) : Ok(false);
        }
    }

}
