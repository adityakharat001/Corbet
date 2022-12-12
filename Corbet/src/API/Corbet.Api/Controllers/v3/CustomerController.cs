using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Customers.Commands.CreateCustomer;
using Corbet.Application.Features.Customers.Commands.CustomerEmailExist;
using Corbet.Application.Features.Customers.Commands.DeleteCustomer;
using Corbet.Application.Features.Customers.Commands.UpdateCustomer;
using Corbet.Application.Features.Customers.Queries.GetAllCustomers;
using Corbet.Application.Features.Customers.Queries.GetCustomerByEmail;
using Corbet.Application.Features.Customers.Queries.GetCustomerById;
using Corbet.Application.Features.Users.Commands.UserEmailExist;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ILogger<CustomerController> _logger;
        readonly ICustomerRepository _customerRepository;

        public CustomerController(IMediator mediator, ILogger<CustomerController> logger, ICustomerRepository customerRepository)
        {
            _mediator = mediator;
            _logger = logger;
            _customerRepository = customerRepository;
        }

        //@author:Rinku


        [HttpPost]
        [Route("AddCustomer")]
        public async Task<ActionResult> CreateCustomer(CreateCustomerCommand Customer)
        {
            _logger.LogInformation("Customer add initiated");
            var addCustomer = await _mediator.Send(Customer);
            _logger.LogInformation("Customer added");
            return Ok(addCustomer);
        }


        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<ActionResult> GetAllCustomersWithRoles()
        {
            _logger.LogInformation("Get Customers Initiated");
            var Customers = await _mediator.Send(new GetAllCustomersQuery());
            _logger.LogInformation("Get Customers Completed");
            return Ok(Customers);
        }


        [HttpGet]
        [Route("GetCustomerByEmail")]
        public async Task<ActionResult> GetCustomerByEmail(string email)
        {
            _logger.LogInformation("Get Customers Initiated");
            var Customers = await _mediator.Send(new GetCustomerByEmailQuery() { Email = email });
            _logger.LogInformation("Get Customers Completed");
            return Ok(Customers);
        }

        [HttpGet]
        [Route("GetCustomerById")]
        public async Task<ActionResult> GetCustomerById(int id)
        {
            _logger.LogInformation("Get Customer Initiated");
            var Customer = await _mediator.Send(new GetCustomerByIdQuery() { CustomerId = id });
            _logger.LogInformation("Get Customer Completed");
            return Ok(Customer);
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            _logger.LogInformation("Update Customer Initiated");
            var response = await _mediator.Send(updateCustomerCommand);
            _logger.LogInformation("Update Customer Completed");
            return Ok(response);
        }


        [HttpPost]
        [Route("CustomerEmailExist")]
        public async Task<ActionResult> CustomerEmailExist(CustomerEmailExistCommand customerEmailExist)
        {
            var emailExist = await _mediator.Send(customerEmailExist);
            return Ok(emailExist);

        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task<ActionResult> DeleteCustomer(int Id)
        {
            _logger.LogInformation("Remove Customer Initiated");
            var dtos = await _mediator.Send(new DeleteCustomerCommand() { CustomerId = Id });
            _logger.LogInformation("Remove Customer Completed");
            return Ok(dtos);
        }
    }
}
