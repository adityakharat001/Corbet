using Corbet.Application.Features.OrderManagement.Command.CreatePurchaseOrder;
using Corbet.Application.Features.PurchaseCart.Command;
using Corbet.Application.Features.PurchaseCart.Command.PurchaseDecrementCart;
using Corbet.Application.Features.PurchaseCart.Command.PurchaseDeleteCart;
using Corbet.Application.Features.PurchaseCart.Command.PurchaseIncrementCart;
using Corbet.Application.Features.PurchaseCart.Command.PurchaseQuantityUpdate;
using Corbet.Application.Features.PurchaseCart.Command.PurchaseRemoveAllCart;
using Corbet.Application.Features.PurchaseCart.Queries.GetAllCart;
using Corbet.Application.Features.PurchaseCart.Queries.GetTotalBill;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PurchaseCartController : ControllerBase
    {


        private readonly ILogger<PurchaseCartController> _logger;
        private readonly IMediator _mediator;
        public PurchaseCartController(ILogger<PurchaseCartController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region AddPurchaseCart
        [HttpPost]
        [Route("AddPurchaseCart")]
        public async Task<ActionResult> CreatePurchaseCart(CreatePurchaseCartCommand createPurchaseCartCommand)
        {
            _logger.LogInformation("Adding Purchase Cart initiated");
            var response = await _mediator.Send(createPurchaseCartCommand);
            if (response == null)
            {
                return BadRequest();
            }
            _logger.LogInformation("Adding Purchase Cart completed");
            return Ok(response);
        }
        #endregion



        #region Getting All PurchasecartDetail

        [HttpGet]
        [Route("PurchaseGetAllCartDetails")]
        public async Task<IActionResult> GetAllCartDetails(int UserId)
        {
            _logger.LogInformation("Cart Details Initiated");
            var CartData = await _mediator.Send(new PurchaseGetAllCartQuery() { userId = UserId });
            _logger.LogInformation("Successfull");
            return Ok(CartData);
        }
        #endregion


        #region DeleteCart
        [HttpDelete]
        [Route("PurchaseDeleteCart")]
        public async Task<IActionResult> PurchaseDeleteCart(int id)
        {
            _logger.LogInformation("cart delete initiated");
            await _mediator.Send(new PurchaseDeleteCartCommand() { CartId = id });
            _logger.LogInformation("Category delete completed");
            return NoContent();
        }
        #endregion


        #region IncreaseCart
        [HttpGet]
        [Route("PurchaseIncreaseCart")]
        public async Task<IActionResult> PurchaseIncreaseQuantityCart(int cartId, int UserId, int stockId, int productId, int Quantity)
        {
            _logger.LogInformation("cart delete initiated");
            PurchaseIncrementCartDto value = await _mediator.Send(new PurchaseIncrementCartCommand() { CartId = cartId, UserId = UserId, stockId = stockId, productId = productId, Quantity = Quantity });
            if (value.Success == true)
            {
                return Ok();
            }
            _logger.LogInformation("Category delete completed");
            return BadRequest();
        }
        #endregion

        #region DecreaseCart
        [HttpGet]
        [Route("PurchaseDecreaseCart")]
        public async Task<IActionResult> DecreaseQuantityCart(int cartId, int UserId, int stockId, int productId, int Quantity)
        {
            _logger.LogInformation("cart decrease initiated");
            PurchaseDecrementCartDto value = await _mediator.Send(new PurchaseDecrementCartCommand() { CartId = cartId, UserId = UserId, stockId = stockId, productId = productId, Quantity = Quantity });
            if (value.Success == true)
            {
                return Ok();
            }
            _logger.LogInformation("Cart Decreasecompleted");
            return BadRequest();
        }
        #endregion

        #region RemoveAllCart
        [HttpDelete]
        [Route("RemoveAllCart")]
        public async Task<IActionResult> RemoveAllCart(int userid)
        {
            _logger.LogInformation("cart delete initiated");
            await _mediator.Send(new PurchaseRemoveAllCartCommand() { UserId = userid });
            _logger.LogInformation("Category delete completed");
            return NoContent();
        }
        #endregion



        #region IncreaseCart
        [HttpGet]
        [Route("QuantityUpdate")]
        public async Task<IActionResult> QuantityUpdate(int cartId, int UserId, int stockId, int productId, int Quantity)
        {
            _logger.LogInformation("Quantity Update initiated");
            PurchaseQuantityUpdateDto value = await _mediator.Send(new PurchaseQuantityUpdateCommand() { CartId = cartId, UserId = UserId, stockId = stockId, productId = productId, Quantity = Quantity });
            if (value.Success == true)
            {
                return Ok();
            }
            _logger.LogInformation("Category delete completed");
            return BadRequest();
        }
        #endregion

        [HttpPost]
        [Route("AddOrder")]
        public async Task<ActionResult> CreateOrder(CreatePurchaseOrderCommand createPurchaseOrderCommand)
        {
            _logger.LogInformation("Adding Order initiated");
            var response = await _mediator.Send(createPurchaseOrderCommand);
            if (response == null)
            {
                return BadRequest();
            }
            _logger.LogInformation("Adding order completed");
            return Ok(response);
        }


        #region TotalBill
        [HttpGet]
        [Route("TotalBill")]
        public async Task<IActionResult> TotalBill(int UserId)
        {
            _logger.LogInformation("Cart Details Initiated");
            var CartData = await _mediator.Send(new PurchaseGetTotalBillQuery() { UserId = UserId });
            _logger.LogInformation("Successfull");
            return Ok(CartData);
        }
        #endregion
    }
}