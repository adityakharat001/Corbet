using Corbet.Application.Features.Taxes.Commands.CheckTaxExist;
using Corbet.Application.Features.Taxes.Commands.CreateTax;
using Corbet.Application.Features.Taxes.Commands.CreateTaxDetail;
using Corbet.Application.Features.Taxes.Commands.DeleteTaxDetail;
using Corbet.Application.Features.Taxes.Commands.DeleteTaxType;
using Corbet.Application.Features.Taxes.Commands.UpdateTax;
using Corbet.Application.Features.Taxes.Commands.UpdateTaxDetail;
using Corbet.Application.Features.Taxes.Queries.GetAllTaxDetails;
using Corbet.Application.Features.Taxes.Queries.GetAllTaxes;
using Corbet.Application.Features.Taxes.Queries.GetTaxById;
using Corbet.Application.Features.Taxes.Queries.GetTaxDetailsById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TaxController> _logger;

        public TaxController(IMediator mediator, ILogger<TaxController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddTaxDetail")]
        public async Task<ActionResult> CreateTaxDetail(CreateTaxDetailCommand createtTaxDetailCommand)
        {
            _logger.LogInformation("Add TaxDetail initiated");
            var response = await _mediator.Send(createtTaxDetailCommand);
            _logger.LogInformation("Add TaxDetail completed");
            return Ok(response);
        }
        
        [HttpPost]
        [Route("AddTax")]
        public async Task<ActionResult> CreateTax(CreateTaxCommand createtTaxCommand)
        {
            _logger.LogInformation("Add Tax initiated");
            var response = await _mediator.Send(createtTaxCommand);
            _logger.LogInformation("Add Tax completed");
            return Ok(response);
        }
        

        [HttpPost]
        [Route("UpdateTax")]
        public async Task<ActionResult> UpdateTax([FromBody] UpdateTaxCommand updateTaxCommand)
        {
            _logger.LogInformation("Update tax Detail initiated");
            var response = await _mediator.Send(updateTaxCommand);
            _logger.LogInformation("Upadte tax Detail completed");
            return Ok(response);
        }



        [HttpPost]
        [Route("UpdateTaxDetail")]
        public async Task<ActionResult> UpdateTaxDetail([FromBody] UpdateTaxDetailCommand updateTaxDetailCommand)
        {
            _logger.LogInformation("Update tax Detail initiated");
            var response = await _mediator.Send(updateTaxDetailCommand);
            _logger.LogInformation("Upadte tax Detail completed");
            return Ok(response);
        }

        [HttpGet]
        [Route("GetTaxDetailsById")]
        public async Task<IActionResult> GetTaxDetailsById(int id)
        {
            _logger.LogInformation("Get tax details initiated");
            var response = await _mediator.Send(new GetTaxDetailsByIdQuery() { Id = id });
            _logger.LogInformation("Get tax details completed");
            return Ok(response);
        }
        

        [HttpGet]
        [Route("GetTaxById")]
        public async Task<IActionResult> GetTaxById(int id)
        {
            _logger.LogInformation("Get tax initiated");
            var response = await _mediator.Send(new GetTaxByIdQuery() { TaxId = id });
            _logger.LogInformation("Get tax completed");
            return Ok(response);
        }


        #region Getting All TaxTypes
        [HttpGet]
        [Route("GetAllTaxes")]
        public async Task<IActionResult> GetAllTaxes()
        {
            _logger.LogInformation("Initiated");
            var taxList = await _mediator.Send(new GetAllTaxesQuery());
            _logger.LogInformation("Successfull");
            return Ok(taxList);
        }

        #endregion



        #region Delete Tax Type
        [HttpDelete]
        [Route("DeleteTaxType")]
        public async Task<IActionResult> DeleteTaxType(int id)
        {
            _logger.LogInformation("Tax delete initiated");
            await _mediator.Send(new DeleteTaxTypeCommand() { TaxId = id });
            _logger.LogInformation("Tax delete completed");
            return NoContent();
        }
        #endregion

        
        #region Delete Tax Details
        [HttpDelete]
        [Route("DeleteTaxDetails")]
        public async Task<IActionResult> DeleteTaxDetails(int id)
        {
            _logger.LogInformation("Tax Details delete initiated");
            await _mediator.Send(new DeleteTaxDetailCommand() { Id = id });
            _logger.LogInformation("Tax Details delete completed");
            return NoContent();
        }
        #endregion


        #region Getting All TaxDetails

        [HttpGet]
        [Route("GetAllTaxDetails")]
        public async Task<IActionResult> GetAllTaxDetails()
        {
            _logger.LogInformation("Details Initiated");
            var taxData = await _mediator.Send(new GetAllTaxDetailsQuery());
            _logger.LogInformation("Successfull");
            return Ok(taxData);
        }
        #endregion



        [Route("DoesTaxExists/{tax}")]
        [HttpGet]
        public async Task<IActionResult> DoesPhoneAlreadyExists(string tax)
        {
            var response = await _mediator.Send(new CheckTaxExistCommand(tax));
            return (response) ? Ok(true) : Ok(false);
        }

    }
}
