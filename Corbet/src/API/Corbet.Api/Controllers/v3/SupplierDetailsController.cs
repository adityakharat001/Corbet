using Corbet.Application.Features.ProductCategoryDetails.Commands.CreateCategoryDetails;
using Corbet.Application.Features.ProductCategoryDetails.Commands.DeletCategoryDetails;
using Corbet.Application.Features.ProductCategoryDetails.Commands.UpdateCategoryDetails;
using Corbet.Application.Features.SuppliersDetails.Command.CreateSupplierDetails;
using Corbet.Application.Features.SuppliersDetails.Command.DeleteSupplierDetails;
using Corbet.Application.Features.SuppliersDetails.Command.UpdateSupplierDetails;
using Corbet.Application.Features.SuppliersDetails.Queries.GetAllSupplierDetails;
using Corbet.Application.Features.SuppliersDetails.Queries.GetSupplierDetailsById;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SupplierDetailsController : ControllerBase
    {
        IMediator _mediator;
        ILogger<ProductCategoryDetailsController> _logger;
        public SupplierDetailsController(IMediator mediator, ILogger<ProductCategoryDetailsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        #region Add Supplier Details Details
        [HttpPost]
        [Route("AddSupplierDetails")]

        public async Task<ActionResult> AddSupplierDetails(CreateSupplierDetailsCommand createSupplierDetailsCommand)
        {
            _logger.LogInformation("creating initiated");
            var supplierDetails = await _mediator.Send(createSupplierDetailsCommand);
            _logger.LogInformation("created successfully");
            return Ok(supplierDetails);
        }
        #endregion


        #region Update Supplier Details
        [HttpPost]
        [Route("UpdateSupplierDetails")]
        public async Task<ActionResult> UpdateSupplierDetails([FromBody] UpdateSupplierDetailsCommand updateSupplierDetailCommand)
        {
            _logger.LogInformation("Update Supplier Details initiated");
            var response = await _mediator.Send(updateSupplierDetailCommand);
            _logger.LogInformation("Upadte Supplier Details completed");
            return Ok(response);
        }
        #endregion

        #region Get All Suppliers Details
        [HttpGet]
        [Route("GetAlSuppliersDetails")]
        public async Task<IActionResult> GetAllSuppliersDetails()
        {
            _logger.LogInformation("");
            var details = await _mediator.Send(new GetAllSupplierDetailsQuery());
            _logger.LogInformation("");
            return Ok(details);
        }
        #endregion

        #region Delete Supplier Details
        [HttpDelete]
        [Route("DeleteSupplierDetails")]
        public async Task<IActionResult> DeleteSupplierDetails(int id)
        {
            _logger.LogInformation("Suppliers Details delete initiated");
            await _mediator.Send(new DeleteSupplierDetailsCommand() { SupplierId = id });
            _logger.LogInformation("Suppliers Details delete completed");
            return NoContent();
        }
        #endregion


        #region get Supplier Details By Id
        [HttpGet]
        [Route("GetSupplierDetailsById")]
        public async Task<IActionResult> GetSupplierDetailsById(int id)
        {
            _logger.LogInformation("get details by id initiated");
            var details = await _mediator.Send(new GetSupplierDetailsByIdQuery() { SupplierId = id });
            _logger.LogInformation("completed");
            return Ok(details);
        }
        #endregion

    }
}
