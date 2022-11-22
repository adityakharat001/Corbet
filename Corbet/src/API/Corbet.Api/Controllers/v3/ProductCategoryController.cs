using Corbet.Application.Features.ProductCategory.Commands.CraeteProductCategory;
using Corbet.Application.Features.ProductCategory.Commands.DeleteProductCategory;
using Corbet.Application.Features.ProductCategory.Commands.UpdateProductCategory;
using Corbet.Application.Features.ProductCategory.Queries.CategoryNameExist;
using Corbet.Application.Features.ProductCategory.Queries.GetAllProductCategories;
using Corbet.Application.Features.ProductCategory.Queries.GetCategoryById;
using Corbet.Application.Features.Roles.Commands.CreateRole;
using Corbet.Application.Features.Roles.Commands.DeleteRole;
using Corbet.Application.Features.Roles.Commands.UpdateRole;
using Corbet.Application.Features.Taxes.Queries.GetAllTaxes;
using Corbet.Application.Features.Taxes.Queries.GetTaxById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {

        private readonly ILogger<ProductCategoryController> _logger;
        private readonly IMediator _mediator;
        public ProductCategoryController(ILogger<ProductCategoryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("AddProductCategory")]
        public async Task<ActionResult> CreateProductCategory(CreateProductCategoryCommand createCategoryCommand)
        {
            _logger.LogInformation("Adding Category initiated");
            var response = await _mediator.Send(createCategoryCommand);
            _logger.LogInformation("Adding Category completed");
            return Ok(response);
        }


        [HttpPost]
        [Route("UpdateCategory")]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateProductCategoryCommand updateCategoryCommand)
        {
            _logger.LogInformation("Update Category initiated");
            var response = await _mediator.Send(updateCategoryCommand);
            _logger.LogInformation("Upadte Category completed");
            return Ok(response);
        }


        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _logger.LogInformation("Category delete initiated");
            await _mediator.Send(new DeleteProductCategoryCommand() { CategoryId= id });
            _logger.LogInformation("Category delete completed");
            return NoContent();
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {  
                _logger.LogInformation("Initiated");
                var categoryList = await _mediator.Send(new GetAllProductCategoriesQuery());
                _logger.LogInformation("Successfull");
                return Ok(categoryList);
        }

        [HttpGet]
        [Route("GetcategoryById")]
        public async Task<IActionResult> GetcategoryById(int id)
        {
            _logger.LogInformation("Get category initiated");
            var response = await _mediator.Send(new GetCategoryByIdQuery() { CategoryId = id });
            _logger.LogInformation("Get category completed");
            return Ok(response);
        }

        [HttpGet]
        [Route("CategoryNameExist")]
        public async Task<IActionResult> CategoryNameExist(string categoryName)
        {
            var response = await _mediator.Send(new CategoryNameExistQuery(categoryName));
            return Ok(response);
        }
    }
}
