using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<DeleteCustomerCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomerCommandHandler(IMapper mapper, ILogger<DeleteCustomerCommandHandler> logger, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public async Task<Response<DeleteCustomerCommandDto>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Delete User Initiated");
            var userDto = await _customerRepository.RemoveCustomerAsync(request.CustomerId);
            _logger.LogInformation("Delete User Completed");
            if (userDto.Succeeded)
            {
                //mapper.Map<DeleteCommandDto>(userdto);
                return new Response<DeleteCustomerCommandDto>(userDto, "Success");
            }
            else
            {
                var res = new Response<DeleteCustomerCommandDto>(userDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();
        }
    }
}
