using Corbet.Application.Features.OrderManagement.Command.UpdatePurchaseOrder;
using Corbet.Application.Features.PurchaseCart.Command;
using Corbet.Application.Features.PurchaseCart.Queries.GetAllOrder;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly ILogger<PurchaseOrderController> _logger;
        private readonly IMediator _mediator;
        public PurchaseOrderController(ILogger<PurchaseOrderController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("AddPurchaseCart")]
        public async Task<ActionResult> CreatePurchaseCart(CreatePurchaseCartCommand createpurchasecartCommand)
        {
            _logger.LogInformation("Adding Cart initiated");
            var response = await _mediator.Send(createpurchasecartCommand);
            if (response == null)
            {
                return BadRequest();
            }
            _logger.LogInformation("Adding Cart completed");
            return Ok(response);
        }
        [HttpGet]
        [Route("PurchaseAllOrder")]
        public async Task<IActionResult> PurchaseAllOrder(int UserId)
        {
            _logger.LogInformation("Cart Details Initiated");
            var CartData = await _mediator.Send(new GetAllOrderQuery() { UserId = UserId });
            _logger.LogInformation("Successfull");
            return Ok(CartData);
        }



        [HttpGet]
        [Route("UpdateOrderStatus")]
        public async Task<ActionResult> UpdateOrderStatus(int UserId, string Status)
        {

            var product = await _mediator.Send(new UpdatePurchaseOrderStatusCommand() { UserId = UserId, Status = Status });
            if (product.Succeeded)
            {
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
