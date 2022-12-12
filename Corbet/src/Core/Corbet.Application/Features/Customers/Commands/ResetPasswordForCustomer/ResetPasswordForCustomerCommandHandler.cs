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

namespace Corbet.Application.Features.Customers.Commands.ResetPasswordForCustomer
{
    public class ResetPasswordForCustomerCommandHandler : IRequestHandler<ResetPasswordForCustomerCommand, Response<ResetPasswordForCustomerDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<ResetPasswordForCustomerCommandHandler> _logger;

        public ResetPasswordForCustomerCommandHandler(ILogger<ResetPasswordForCustomerCommandHandler> logger, IMapper mapper, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Response<ResetPasswordForCustomerDto>> Handle(ResetPasswordForCustomerCommand request, CancellationToken cancellationToken)
        {
            string newPassword;
            var user = _mapper.Map<Customer>(request);
            var userData = await _customerRepository.GetCustomerByEmail(user.Email);
            if (userData is not null)
            {
                newPassword = EncryptionDecryption.EncryptString(request.Password);
                if (userData.Password.Equals(newPassword))
                {
                    return new Response<ResetPasswordForCustomerDto>() { Succeeded = false, Errors = new List<string>() { "New Password and Old Password Shouldn't be same. Try Different Password" } };
                }
                else
                {
                    userData.Password = newPassword;
                    await _customerRepository.UpdateAsync(userData);
                    var ResetPasswordForCustomerDto = _mapper.Map<ResetPasswordForCustomerDto>(userData);
                    return new Response<ResetPasswordForCustomerDto>() { Data = ResetPasswordForCustomerDto, Succeeded = true };
                }
            }
            else
            {
                return new Response<ResetPasswordForCustomerDto>() { Succeeded = false };
            }
        }
    }
}
