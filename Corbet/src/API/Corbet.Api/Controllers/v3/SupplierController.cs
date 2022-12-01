using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.ProductCategory.Commands.CraeteProductCategory;
using Corbet.Application.Features.Roles.Commands.UpdateRole;
using Corbet.Application.Features.Roles.Queries.GetRoleById;
using Corbet.Application.Features.Suppliers.Commands.CheckSupplierExists;
using Corbet.Application.Features.Suppliers.Commands.CreateSupplier;
using Corbet.Application.Features.Suppliers.Commands.DeleteSupplier;
using Corbet.Application.Features.Suppliers.Commands.UpdateSupplier;
using Corbet.Application.Features.Suppliers.Queries.GetAllSuppliers;
using Corbet.Application.Features.Suppliers.Queries.GetSupplierById;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ILogger<SupplierController> _logger;
        readonly ISupplierRepository _supplierRepository;

        public SupplierController(IMediator mediator, ILogger<SupplierController> logger, ISupplierRepository supplierRepository)
        {
            _mediator = mediator;
            _logger = logger;
            _supplierRepository = supplierRepository;
        }


        [HttpPost]
        [Route("AddSupplier")]
        public async Task<ActionResult> CreateSupplier(CreateSupplierCommand supplier)
        {
            _logger.LogInformation("Supplier add initiated");
            var addSupplier = await _mediator.Send(supplier);
            _logger.LogInformation("Supplier added completed");
            return Ok(addSupplier);
        }

        [HttpGet]
        [Route("GetAllSuppliers")]
        public async Task<ActionResult> GetAllSuppliers()
        {
            _logger.LogInformation("Get Suppliers Initiated");
            var suppliers = await _mediator.Send(new GetAllSuppliersQuery());
            _logger.LogInformation("Get Suppliers Completed");
            return Ok(suppliers);
        }

        [HttpGet]
        [Route("GetAllSuppliersForPurchaseUser")]
        public async Task<ActionResult> GetAllSuppliersForPurchaseUser()
        {
            _logger.LogInformation("Get Suppliers Initiated");
            var suppliers = await _mediator.Send(new GetAllSuppliersForPurchaseUserQuery());
            _logger.LogInformation("Get Suppliers Completed");
            return Ok(suppliers);
        }

        [HttpGet]
        [Route("GetSupplierById")]
        public async Task<ActionResult> GetSupplierById(int id)
        {
            _logger.LogInformation("Get Supplier Initiated");
            var supplier = await _mediator.Send(new GetSupplierByIdQuery() { SupplierId = id });
            _logger.LogInformation("Get Supplier Completed");
            return Ok(supplier);
        }


        [HttpPost]
        [Route("UpdateSupplierForPurchaseUser")]
        public async Task<ActionResult> UpdateSupplierForPurchaseUser([FromBody] UpdateSupplierCommand updateSupplierCommand)
        {
            _logger.LogInformation("Update Supplier Initiated");
            var response = await _mediator.Send(updateSupplierCommand);
            _logger.LogInformation("Update Supplier Completed");
            return Ok(response);
        }

        [HttpPost]
        [Route("UpdateSupplierForAdmin")]
        public async Task<ActionResult> UpdateSupplierForAdmin([FromBody] UpdateSupplierAdminCommand updateSupplierAdminCommand)
        {
            _logger.LogInformation("Update Supplier for admin Initiated");
            var response = await _mediator.Send(updateSupplierAdminCommand);
            _logger.LogInformation("Update Supplier for admin Completed");
            return Ok(response);
        }


        [HttpDelete]
        [Route("DeleteSupplier")]
        public async Task<ActionResult> DeleteSupplier(int Id)
        {
            _logger.LogInformation("Remove Supplier Initiated");
            var dtos = await _mediator.Send(new DeleteSupplierCommand() { SupplierId = Id });
            _logger.LogInformation("Remove Supplier Completed");
            return Ok(dtos);
        }

        [HttpGet]
        [Route("ToggleActiveStatus")]
        public async Task<ActionResult> ToggleActiveStatus(int supplierId)
        {
            bool isActive = await _supplierRepository.ToggleActiveStatus(supplierId);
            return (isActive) ? Ok("Active") : Ok("InActive");
        }

        [Route("CheckSupplierExists")]
        [HttpGet]
        public async Task<IActionResult> CheckSupplierExists(string supplierName)
        {
            var response = await _mediator.Send(new CheckSupplierExistsCommand() { SupplierName = supplierName });
            return Ok(response);
        }
    }
}
