using AutoMapper;
using Corbet.Application.Contracts.Infrastructure;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Models.Mail;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<UpdateUserCommandDto>>
    {
        private readonly ILogger<UpdateUserCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailservice;


        public UpdateUserCommandHandler(ILogger<UpdateUserCommandHandler> logger, IMapper mapper, IUserRepository userRepository, IEmailService emailservice)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;
            _emailservice = emailservice;
        }

        //public async Task<Response<UpdateUserCommandDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        //{
        //    var userToUpdate = await _userRepository.GetById(request.UserId);

        //    var userData = _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(User));
        //    await _userRepository.UpdateAsync(userToUpdate);
        //    var userDto = _mapper.Map<UpdateUserCommandDto>(userData);
        //    return new Response<UpdateUserCommandDto>(userDto);

        //}

        public async Task<Response<UpdateUserCommandDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {


            var userToUpdate = await _userRepository.GetById(request.UserId);
            string oldEmail = userToUpdate.Email;
            var userData = _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(User));
            await _userRepository.UpdateAsync(userToUpdate);
            if (oldEmail != userToUpdate.Email)
            {
                var email = new Email()
                {
                    To = userToUpdate.Email,
                    Body = $"Dear User, <br/><br/>Hope you are doing well.<br/>Your Email is updated successfully on the CORBET portal <br/>\r\n Kindly refer below credentials to Login.<br/>\r\nUsername : {userToUpdate.Email} <br/><br /> <br/>Regards, <br/> Team Support",
                    Subject = "User Email Updated Successfully!!"
                };
                bool value = await _emailservice.SendEmail(email);
            }
            var userDto = _mapper.Map<UpdateUserCommandDto>(userData);
            return new Response<UpdateUserCommandDto>(userDto);

        }
    }
}
