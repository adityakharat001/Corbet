using Corbet.Application.Features.ProductCategory.Queries.GetCategoryById;
using Corbet.Application.Features.ProductCategoryDetails.Commands.CreateCategoryDetails;
using Corbet.Application.Features.ProductCategoryDetails.Commands.DeletCategoryDetails;
using Corbet.Application.Features.ProductCategoryDetails.Commands.UpdateCategoryDetails;
using Corbet.Application.Features.ProductCategoryDetails.Queries.GetAllCategoryDetails;
using Corbet.Application.Features.ProductCategoryDetails.Queries.GetcategoryDetailsById;
using Corbet.Application.Features.Taxes.Commands.DeleteTaxDetail;
using Corbet.Application.Features.Taxes.Commands.UpdateTaxDetail;
using Corbet.Application.Features.Taxes.Queries.GetAllTaxDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductCategoryDetailsController : ControllerBase
    {

        IMediator _mediator;
        ILogger<ProductCategoryDetailsController> _logger;
        public ProductCategoryDetailsController(IMediator mediator, ILogger<ProductCategoryDetailsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }



        #region Add Category Details
        [HttpPost]
        [Route("AddCategoryDetails")]

        public async Task<ActionResult> AddCategoryDetails(CreateCategoryDetailsCommand createCategoryDetailsCommand)
        {
            _logger.LogInformation("creating initiated");
            var categoryDetails=await _mediator.Send(createCategoryDetailsCommand);
            _logger.LogInformation("created successfully");
            return Ok(categoryDetails);
        }
#endregion


        #region Update Category Details
        [HttpPost]
        [Route("UpdateCategoryDetails")]
        public async Task<ActionResult> UpdateCategoryDetails([FromBody] UpdateCategoryDetailsCommand updateCategoryDetailCommand)
        {
            _logger.LogInformation("Update Category Detail initiated");
            var response = await _mediator.Send(updateCategoryDetailCommand);
            _logger.LogInformation("Upadte Category Detail completed");
            return Ok(response);
        }
#endregion



        #region Delete Category Details
        [HttpDelete]
        [Route("DeleteCategoryDetails")]
        public async Task<IActionResult> DeleteCategoryDetails(int id)
        {
            _logger.LogInformation("Category Details delete initiated");
            await _mediator.Send(new DeleteCategoryDetailsCommand() {Id = id });
            _logger.LogInformation("Category Details delete completed");
            return NoContent();
        }
        #endregion



        #region Getting All Category Details

        [HttpGet]
        [Route("GetAllCategoryDetails")]
        public async Task<IActionResult> GetAllCategoryDetails()
        {
            _logger.LogInformation("Details Initiated");
            var categoryData = await _mediator.Send(new GetAllCategoryDetailsQuery());
            _logger.LogInformation("Successfull");
            return Ok(categoryData);
        }
        #endregion


        #region GetcategoryDetailsById

        [HttpGet]
        [Route("GetcategoryDetailsById")]
        public async Task<IActionResult> GetcategoryDetailsById(int id)
        {
            _logger.LogInformation("Get category initiated");
            var response = await _mediator.Send(new GetCategoryDetailsByIdQuery() { Id = id });
            _logger.LogInformation("Get category completed");
            return Ok(response);
        }
        #endregion
    }
}
