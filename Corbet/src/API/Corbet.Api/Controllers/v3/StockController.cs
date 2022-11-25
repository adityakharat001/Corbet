using Corbet.Application.Features.Products.Commands.CheckProductExistsInStockList;
using Corbet.Application.Features.Stocks.Commands.AddStock;
using Corbet.Application.Features.Stocks.Commands.DeleteStock;
using Corbet.Application.Features.Stocks.Commands.UpdateStock;
using Corbet.Application.Features.Stocks.Queries.GetAllStocks;
using Corbet.Application.Features.Stocks.Queries.GetStockByStockId;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StockController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [Route("AddStock")]
        [HttpPost]
        public async Task<IActionResult> AddStock(AddStockCommand addStockCommand)
        {
            var response = await _mediator.Send(addStockCommand);
            return (response.Succeeded) ? Ok(response) : Conflict(response);
        }

        [Route("GetAllStocks")]
        [HttpGet]
        public async Task<IActionResult> GetAllStocks()
        {
            var response = await _mediator.Send(new GetAllStocksQuery());
            return Ok(response);
        }

        [Route("GetStockByStockId/{stockId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetStockByStockId(int stockId)
        {
            var response = await _mediator.Send(new GetStockByStockIdQuery() { StockId = stockId });
            return (response.Succeeded) ? Ok(response) : NotFound(response);
        }

        [Route("DeleteStock/{stockId:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStock(int stockId)
        {
            var response = await _mediator.Send(new DeleteStockCommand() { StockId = stockId });
            return (response.Succeeded) ? Ok(response) : NotFound(response);
        }

        [Route("UpdateStock/{stockId:int}")]
        [HttpPut]
        public async Task<IActionResult> UpdateStock(int stockId, UpdateStockCommand updateStockCommand)
        {
            var response = await _mediator.Send(new UpdateStockCommand()
            {
                StockId = stockId,
                ProductId = updateStockCommand.ProductId,
                Quantity = updateStockCommand.Quantity,
                StockTypeId = updateStockCommand.StockTypeId,
                TimeIn = updateStockCommand.TimeIn,
                TimeOut = updateStockCommand.TimeOut
            });
            return (response.Succeeded) ? Ok(response) : NotFound(response);
        }

        [Route("CheckProductAlreadyExistsInStockList")]
        [HttpGet]
        public async Task<IActionResult> CheckProductAlreadyExistsInStockList(int productId)
        {
            var response = await _mediator.Send(new CheckProductExistsInStockListCommand() { ProductId = productId });
            return Ok(response);
        }
    }
}
