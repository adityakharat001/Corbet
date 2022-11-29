using Corbet.Application.Features.AddCart.Command;
using Corbet.Application.Features.AddCart.Queries;
using Corbet.Application.Features.Invoice.Command.CreateInvoice;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly  ILogger<InvoiceController> _logger;

        public InvoiceController(IMediator mediator, ILogger<InvoiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddInvoice")]
        public async Task<ActionResult> CreateInvoice(CreateInvoiceCommand createinvoiceCommand)
        {
            _logger.LogInformation("Creating invoice initiated");
            var response = await _mediator.Send(createinvoiceCommand);
            if (response == null)
            {
                return BadRequest();
            }
            _logger.LogInformation("Creating invoice completed");
            return Ok(response);
        }

        #region Getting All Invoices

        //[HttpGet]
        //[Route("GetAllInvoices")]
        //public async Task<IActionResult> GetAllInvoices(int InvoiceId)
        //{
        //    _logger.LogInformation("Cart Details Initiated");
        //    var InvoiceData = await _mediator.Send(new GetInvoiceListQuery() { });
        //    _logger.LogInformation("Successfull");
        //    return Ok(CartData);
        //}
        #endregion
    }
}
