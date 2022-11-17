using AutoMapper;
using Corbet.Application.Contracts.Persistence;
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

namespace Corbet.Application.Features.Users.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Response<ResetPasswordDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ResetPasswordCommandHandler> _logger;

        public ResetPasswordCommandHandler(ILogger<ResetPasswordCommandHandler> logger, IMapper mapper, IUserRepository userRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Response<ResetPasswordDto>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            string newPassword;
            var user = _mapper.Map<User>(request);
            var userData = await _userRepository.GetUserByEmail(user.Email);
            if (userData is not null)
            {
                newPassword = EncryptionDecryption.EncryptString(request.Password);
                if (userData.Password.Equals(newPassword))
                {
                    return new Response<ResetPasswordDto>() { Succeeded = false, Errors = new List<string>() { "New Password and Old Password Shouldn't be same. Try Different Password" } };
                }
                else
                {
                    userData.Password = newPassword;
                    await _userRepository.UpdateAsync(userData);
                    var resetPasswordDto = _mapper.Map<ResetPasswordDto>(userData);
                    return new Response<ResetPasswordDto>() { Data = resetPasswordDto, Succeeded = true };
                }
            }
            else
            {
                return new Response<ResetPasswordDto>() { Succeeded = false };
            }
        }
    }
}
