using Corbet.Application.Features.ProductCategory.Commands.CraeteProductCategory;
using Corbet.Application.Features.Roles.Commands.UpdateRole;
using Corbet.Application.Features.Roles.Queries.GetRoleById;
using Corbet.Application.Features.Suppliers.Commands.CreateSupplier;
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
        private readonly IMediator _mediator;
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(IMediator mediator, ILogger<SupplierController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //add suppliers
        #region Add Suupliers
        [HttpPost]
        [Route("AddSupplier")]
        public async Task<ActionResult> AddSupplier(CreateSupplierCommand createSupplierCommand)
        {
            _logger.LogInformation("Adding Supplier initiated");
            var response = await _mediator.Send(createSupplierCommand);
            _logger.LogInformation("Adding Supplier completed");
            return Ok(response);
        }
        #endregion


        //update suppliers
        #region Update Supplier
        [HttpPost]
        [Route("UpdateSupplier")]
        public async Task<ActionResult> UpdateSupplier([FromBody] UpdateSupplierCommand updateSupplierCommand)
        {
            _logger.LogInformation("Update Supplier initiated");
            var response = await _mediator.Send(updateSupplierCommand);
            _logger.LogInformation("Upadte Supplier completed");
            return Ok(response);
        }
#endregion 


        //get alll supplier
        #region Get All Suppliers
        [HttpGet]
        [Route("GetAllSuppliers")]
        public async Task<ActionResult> GetAllSuppliers()
        {
            _logger.LogInformation("Get All Suplliers initiated");
            var response = await _mediator.Send(new GetAllSuppliersQuery());
            _logger.LogInformation("Get All Suppliers completed");
            return Ok(response);
        }
        #endregion


        //get supplier by Id
        #region Get SUpplier By ID
        [HttpGet]
        [Route("GetSupplierById")]
        public async Task<IActionResult> GetSupplierById(int id)
        {
            _logger.LogInformation("Get Supplier by Id initiated");
            var role = await _mediator.Send(new GetSupplierByIdQuery() { Id = id });
            _logger.LogInformation("Get Supplier by Id completed");
            return Ok(role);
        }
        #endregion
    }
}
