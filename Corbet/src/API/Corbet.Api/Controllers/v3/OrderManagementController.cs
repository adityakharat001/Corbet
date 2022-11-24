using Corbet.Application.Features.OrderManagement.Command;
using Corbet.Application.Features.OrderManagement.Queries;
using Corbet.Application.Features.ProductSubCategory.Command.CreateSubCategory;
using Corbet.Application.Features.Taxes.Queries.GetAllTaxDetails;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{

    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrderManagementController : ControllerBase
    {
        private readonly ILogger<OrderManagementController> _logger;
        private readonly IMediator _mediator;
        public OrderManagementController(ILogger<OrderManagementController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<ActionResult> CreateOrder(CreateOrderCommand createorderCommand)
        {
            _logger.LogInformation("Adding Order initiated");
            var response = await _mediator.Send(createorderCommand);
            if (response == null)
            {
                return BadRequest();
            }
            _logger.LogInformation("Adding Order completed");
            return Ok(response);
        }


        #region Getting All OrderDetail

        [HttpGet]
        [Route("GetAllOrderDetails")]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            _logger.LogInformation("Order Details Initiated");
            var orderData = await _mediator.Send(new GetOrderListQuery());
            _logger.LogInformation("Successfull");
            return Ok(orderData);
        }
        #endregion

    }
}