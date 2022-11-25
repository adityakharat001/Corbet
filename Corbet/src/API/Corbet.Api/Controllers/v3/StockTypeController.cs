using Corbet.Application.Features.StockTypes.Commands.AddStockType;
using Corbet.Application.Features.StockTypes.Commands.CheckStockTypeExists;
using Corbet.Application.Features.StockTypes.Commands.DeleteStockType;
using Corbet.Application.Features.StockTypes.Commands.UpdateStockType;
using Corbet.Application.Features.StockTypes.Queries.GetAllStockTypes;
using Corbet.Application.Features.StockTypes.Queries.GetStockTypeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StockTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockTypeController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [Route("AddStockType")]
        [HttpPost]
        public async Task<IActionResult> AddStockType(AddStockTypeCommand addStockTypeCommand)
        {
            var response = await _mediator.Send(addStockTypeCommand);
            return (response.Succeeded) ? Ok(response) : Conflict(response);
        }

        [Route("GetAllStockTypes")]
        [HttpGet]
        public async Task<IActionResult> GetAllStockTypes()
        {
            var response = await _mediator.Send(new GetAllStockTypesQuery());
            return Ok(response);
        }

        [Route("GetStockTypeById/{stockTypeId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetAllStockTypes(int stockTypeId)
        {
            var response = await _mediator.Send(new GetStockTypeByIdQuery() { StockTypeId = stockTypeId });
            return (response.Succeeded) ? Ok(response) : NotFound(response);
        }

        [Route("DeleteStockType/{stockTypeId:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStockType(int stockTypeId)
        {
            var response = await _mediator.Send(new DeleteStockTypeCommand() { StockTypeId = stockTypeId });
            return (response.Succeeded) ? Ok(response) : NotFound(response);
        }

        [Route("UpdateStockType/{stockTypeId:int}")]
        [HttpPut]
        public async Task<IActionResult> UpdateStockType(int stockTypeId, UpdateStockTypeCommand updateStockTypeCommand)
        {
            var response = await _mediator.Send(new UpdateStockTypeCommand()
            {
                StockTypeId = stockTypeId,
                StockTypeName = updateStockTypeCommand.StockTypeName
            });
            return (response.Succeeded) ? Ok(response) : NotFound(response);
        }

        [Route("CheckStockTypeAlreadyExists")]
        [HttpGet]
        public async Task<IActionResult> CheckStockTypeAlreadyExists(string stockTypeName)
        {
            var response = await _mediator.Send(new CheckStockTypeExistsCommand() { StockTypeName = stockTypeName });
            return Ok(response);
        }
    }
}
