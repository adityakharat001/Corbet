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

namespace Corbet.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<CreateCustomerCommandDto>>
    {
        private readonly ILogger<CreateCustomerCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmailService _emailservice;


        public CreateCustomerCommandHandler(ILogger<CreateCustomerCommandHandler> logger, IMapper mapper, ICustomerRepository customerRepository, IEmailService emailservice, IRoleRepository roleRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _customerRepository = customerRepository;
            _roleRepository = roleRepository;
            _emailservice = emailservice;
        }

        public async Task<Response<CreateCustomerCommandDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Adding User Information initiated");

            //map user table
            var user = _mapper.Map<Customer>(request);


            string encPassword = EncryptionDecryption.EncryptString(request.Password);
            user.Password = encPassword.ToString();
            var userDto = await _customerRepository.RegisterCustomerAsync(user);
            _logger.LogInformation("Handle Completed");
            if (userDto.Succeeded)
            {
                var lnkHref = $"<button><a href='https://localhost:7221/Customer/CustomerLogin'>Click Here</a></button>";
                var email = new Email()
                {
                    To = request.Email,
                    Body = $"Dear Customer, <br/><br/>Your account has been registered successfully on the CORBET Portal.<br/>We welcome you on our portal.<br/>\r\n  Kindly refer below credentials to Login.<br/>\r\nUsername : {request.Email} <br/>\r\nPassword : {request.Password}.<br /><br>Click here to Login:{lnkHref} <br/>Regards, <br/> Team. Support",
                    Subject = "Customer Registration Successful!!"
                };
                bool value = await _emailservice.SendEmail(email);
                if (value)
                {
                    //bool EmailVerifiedCheck = await _customerRepository.EmailVerified(user);
                    return new Response<CreateCustomerCommandDto>(userDto, "success with Email Verified");
                }

                return new Response<CreateCustomerCommandDto>(userDto, "success without Email Verified");
            }
            else
            {
                var res = new Response<CreateCustomerCommandDto>(userDto, "Failed");
                res.Succeeded = false;
                return res;

            }
        }
    }
}
