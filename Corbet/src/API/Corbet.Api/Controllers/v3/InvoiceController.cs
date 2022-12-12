using Corbet.Application.Features.AddCart.Command;
using Corbet.Application.Features.AddCart.Queries;
using Corbet.Application.Features.Invoice.Command.CreateInvoice;
using Corbet.Application.Features.Invoice.Queries.GetAllInvoice;
using Corbet.Application.Features.Invoice.Queries.GetInvoiceById;
using Corbet.Application.Features.ProductCategory.Queries.GetAllProductCategories;
using Corbet.Application.Features.Suppliers.Queries.GetSupplierById;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
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


        [HttpGet]
        [Route("GetAllInvoices")]
        public async Task<IActionResult> GetAllInvoices()
        {
            _logger.LogInformation("Initiated");
            var invoiceList = await _mediator.Send(new GetAllInvoiceQuery());
            _logger.LogInformation("Successfull");
            return Ok(invoiceList);
        }
        #endregion


        [HttpGet]
        [Route("GetInvoiceById")]
        public async Task<ActionResult> GetInvoiceById(int id)
        {
            _logger.LogInformation("Get Invoice Initiated");
            var invoice = await _mediator.Send(new GetInvoiceByIdQuery() { Id = id });
            _logger.LogInformation("Get Invoice Completed");
            return Ok(invoice);
        }
    }
}
