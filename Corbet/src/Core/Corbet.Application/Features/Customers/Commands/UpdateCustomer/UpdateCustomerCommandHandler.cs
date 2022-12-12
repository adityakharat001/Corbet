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

namespace Corbet.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<UpdateCustomerCommandDto>>
    {
        private readonly ILogger<UpdateCustomerCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailservice;


        public UpdateCustomerCommandHandler(ILogger<UpdateCustomerCommandHandler> logger, IMapper mapper, ICustomerRepository customerRepository, IEmailService emailservice)
        {
            _logger = logger;
            _mapper = mapper;
            _customerRepository = customerRepository;
            _emailservice = emailservice;
        }

        //public async Task<Response<UpdateCustomerCommandDto>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        //{
        //    var userToUpdate = await _customerRepository.GetById(request.UserId);

        //    var userData = _mapper.Map(request, userToUpdate, typeof(UpdateCustomerCommand), typeof(User));
        //    await _customerRepository.UpdateAsync(userToUpdate);
        //    var userDto = _mapper.Map<UpdateCustomerCommandDto>(userData);
        //    return new Response<UpdateCustomerCommandDto>(userDto);

        //}

        public async Task<Response<UpdateCustomerCommandDto>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {


            var userToUpdate = await _customerRepository.GetById(request.CustomerId);
            string oldEmail = userToUpdate.Email;
            var userData = _mapper.Map(request, userToUpdate, typeof(UpdateCustomerCommand), typeof(User));
            await _customerRepository.UpdateAsync(userToUpdate);
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
            var userDto = _mapper.Map<UpdateCustomerCommandDto>(userData);
            return new Response<UpdateCustomerCommandDto>(userDto);

        }
    }
}
