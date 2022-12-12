using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using Corbet.Infrastructure.EncryptDecrypt;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Customers.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Response<ChangePasswordDto>>
    {

        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<ChangePasswordCommandHandler> _logger;

        public ChangePasswordCommandHandler(ILogger<ChangePasswordCommandHandler> logger, IMapper mapper, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Response<ChangePasswordDto>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            string oldPassword;
            string newPassword;
            var user = _mapper.Map<Customer>(request);
            var userData = await _customerRepository.GetById(user.CustomerId);
            if (userData is not null)
            {
                oldPassword = EncryptionDecryption.EncryptString(request.OldPassword);
                if (userData.Password == oldPassword)
                {
                    newPassword = EncryptionDecryption.EncryptString(request.NewPassword);
                    if (userData.Password.Equals(newPassword))
                    {
                        return new Response<ChangePasswordDto>() { Succeeded = false, Errors = new List<string>() { "New Password and Old Password Shouldn't be same. Try Different Password" } };
                    }
                    else
                    {
                        userData.Password = newPassword;
                        await _customerRepository.UpdateAsync(userData);
                        var ChangePasswordDto = _mapper.Map<ChangePasswordDto>(userData);
                        return new Response<ChangePasswordDto>() { Data = ChangePasswordDto, Succeeded = true };
                    }
                }
                return new Response<ChangePasswordDto>() { Succeeded = false };
            }
            else
            {
                return new Response<ChangePasswordDto>() { Succeeded = false };
            }
        }
    }
}
