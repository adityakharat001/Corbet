using AutoMapper;
using Corbet.Application.Contracts.Infrastructure;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Models.Mail;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using Corbet.Infrastructure.EncryptDecrypt;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Corbet.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<CreateUserCommandDto>>
    {
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailservice;


        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, IMapper mapper, IUserRepository userRepository, IEmailService emailservice)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;
            _emailservice = emailservice;
        }

        public async Task<Response<CreateUserCommandDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Adding User Information initiated");

            //map user table
            var user = _mapper.Map<User>(request);


            string encPassword = EncryptionDecryption.EncryptString(request.Password);
            user.Password = encPassword.ToString();

            var userDto = await _userRepository.RegisterUserAsync(user);
            _logger.LogInformation("Handle Completed");
            if (userDto.Succeeded)
            {
                var lnkHref = $"<button><a href='https://localhost:7221/'>Click Here</a></button>";
                var email = new Email()
                {
                    To = request.Email,
                    Body = $"Dear User, <br/><br/>Your account has been registered successfully on the CORBET Portal.<br/>We welcome you on our portal.<br/>\r\n  Kindly refer below credentials to Login.<br/>\r\nUsername : {request.Email} <br/>\r\nPassword : {request.Password}.<br /><br>Click here to Login:{lnkHref} <br/>Regards, <br/> Team. Support",
                    Subject = "User Registration Successful!!"
                };
                bool value = await _emailservice.SendEmail(email);
                if (value)
                {
                    //bool EmailVerifiedCheck = await _userRepository.EmailVerified(user);
                    return new Response<CreateUserCommandDto>(userDto, "success with Email Verified");
                }

                return new Response<CreateUserCommandDto>(userDto, "success without Email Verified");
            }
            else
            {
                var res = new Response<CreateUserCommandDto>(userDto, "Failed");
                res.Succeeded = false;
                return res;

            }
        }
    }
}
