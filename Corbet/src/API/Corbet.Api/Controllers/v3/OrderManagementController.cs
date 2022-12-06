
using Corbet.Application.Features.AddCart.Command;
using Corbet.Application.Features.AddCart.Command.DecreaseCartItem;
using Corbet.Application.Features.AddCart.Command.DeleteCart;
using Corbet.Application.Features.AddCart.Command.RemoveAllCart;
using Corbet.Application.Features.AddCart.Queries;
using Corbet.Application.Features.AddCart.Queries.GetProductSupplier;
using Corbet.Application.Features.AddCart.Queries.GetTotalBill;
using Corbet.Application.Features.OrderManagement.Command.CreateOrder;
using Corbet.Application.Features.OrderManagement.Queries.GetAllState;
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
        //[HttpPost]
        //[Route("AddOrder")]
        //public async Task<ActionResult> CreateOrder(CreateOrderCommand createorderCommand)
        //{
        //    _logger.LogInformation("Adding Order initiated");
        //    var response = await _mediator.Send(createorderCommand);
        //    if (response == null)
        //    {
        //        return BadRequest();
        //    }
        //    _logger.LogInformation("Adding order completed");
        //    return Ok(response);
        //}
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
            var CartData = await _mediator.Send(new GetCartListQuery() { userId = UserId });
            _logger.LogInformation("Successfull");
            return Ok(CartData);
        }
        #endregion

        #region Getting All productSupplierDetail

        [HttpGet]
        [Route("GetAllProductDetails")]
        public async Task<IActionResult> GetAllProductSupplierDetails()
        {
            _logger.LogInformation("Product Supplier Details Initiated");
            var ProductData = await _mediator.Send(new GetProductSupplierListQuery());
            _logger.LogInformation("Successfull");
            return Ok(ProductData);
        }
        #endregion

        #region TotalBill
        [HttpGet]
        [Route("TotalBill")]
        public async Task<IActionResult> TotalBill(int UserId)
        {
            _logger.LogInformation("Cart Details Initiated");
            var CartData = await _mediator.Send(new GetTotalBillQuery() { UserId = UserId });
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
            await _mediator.Send(new DeleteCartCommand() { CartId = id });
            _logger.LogInformation("Category delete completed");
            return NoContent();
        }
        #endregion

        #region DeleteCart
        [HttpDelete]
        [Route("RemoveAllCart")]
        public async Task<IActionResult> RemoveAllCart(int userid)
        {
            _logger.LogInformation("cart delete initiated");
            await _mediator.Send(new RemoveAllCartCommand() { UserId = userid });
            _logger.LogInformation("Category delete completed");
            return NoContent();
        }
        #endregion


        #region IncreaseCart
        [HttpGet]
        [Route("IncreaseCart")]
        public async Task<IActionResult> IncreaseQuantityCart(int cartId,int UserId,int stockId,int productId,int Quantity)
        {
            _logger.LogInformation("cart delete initiated");
         IncreaseCartItemCommandDto  value=   await _mediator.Send(new IncreaseCartItemCommand() { CartId = cartId, UserId=UserId, stockId= stockId, productId= productId, Quantity= Quantity });
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
        [Route("DecreaseCart")]
        public async Task<IActionResult> DecreaseQuantityCart(int cartId, int UserId, int stockId, int productId, int Quantity)
        {
            _logger.LogInformation("cart decrease initiated");
            DecreaseCartItemCommandDto value = await _mediator.Send(new DecreaseCartItemCommand() { CartId = cartId, UserId = UserId, stockId = stockId, productId = productId, Quantity = Quantity });
            if (value.Success == true)
            {
                return Ok();
            }
            _logger.LogInformation("Cart Decreasecompleted");
            return BadRequest();
        }
        #endregion



        #region GetAllState
        [HttpGet]
        [Route("GetAllState")]
        public async Task<IActionResult> GetAllState()
        {
            _logger.LogInformation("Cart Details Initiated");
            var StateData = await _mediator.Send(new GetAllStateQuery());
            _logger.LogInformation("Successfull");
            return Ok(StateData);
        }
        #endregion
    }
}