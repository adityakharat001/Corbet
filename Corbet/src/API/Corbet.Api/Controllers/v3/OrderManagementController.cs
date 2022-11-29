
using Corbet.Application.Features.AddCart.Command;
using Corbet.Application.Features.AddCart.Command.DeleteCart;
using Corbet.Application.Features.AddCart.Queries;
using Corbet.Application.Features.OrderManagement.Command.CreateOrder;
using Corbet.Application.Features.ProductCategory.Commands.DeleteProductCategory;
using Corbet.Application.Features.ProductSubCategory.Command.CreateSubCategory;
using Corbet.Application.Features.Roles.Commands.DeleteRole;
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


        #region AddOrder
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
            _logger.LogInformation("Adding order completed");
            return Ok(response);
        }
        #endregion

        [HttpPost]
        [Route("AddCart")]
        public async Task<ActionResult> Createcart(CreateCartCommand createcartCommand)
        {
            _logger.LogInformation("Adding Cart initiated");
            var response = await _mediator.Send(createcartCommand);
            if (response == null)
            {
                return BadRequest();
            }
            _logger.LogInformation("Adding Cart completed");
            return Ok(response);
        }


        #region Getting All cartDetail

        [HttpGet]
        [Route("GetAllCartDetails")]
        public async Task<IActionResult> GetAllCartDetails(int UserId)
        {
            _logger.LogInformation("Cart Details Initiated");
            var CartData = await _mediator.Send(new GetCartListQuery() { userId=UserId});
            _logger.LogInformation("Successfull");
            return Ok(CartData);
        }
        #endregion



        #region DeleteCart
        [HttpDelete]
        [Route("DeleteCart")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            _logger.LogInformation("cart delete initiated");
            await _mediator.Send(new DeleteCartCommand(){ CartId = id});
            _logger.LogInformation("Category delete completed");
            return NoContent();
        }
        #endregion



    }
}