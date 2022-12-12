using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.ProductCategory.Commands.DeleteProductCategory;
using Corbet.Application.Features.ProductSubCategory.Command.CreateSubCategory;
using Corbet.Application.Features.ProductSubCategory.Command.DeleteSubCategory;
using Corbet.Application.Features.ProductSubCategory.Command.SubCategoryExist;
using Corbet.Application.Features.ProductSubCategory.Command.UpdateSubCategory;
using Corbet.Application.Features.ProductSubCategory.Queries.GetSubCategoryByCategoryId;
using Corbet.Application.Features.ProductSubCategory.Queries.GetSubCategoryById;
using Corbet.Application.Features.ProductSubCategory.Queries.GetSubCategoryList;
using Corbet.Application.Features.Roles.Queries.GetAllRoles;
using Corbet.Application.Features.Taxes.Commands.UpdateTaxDetail;
using Corbet.Application.Features.Taxes.Queries.GetTaxDetailsById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductSubCategoryController : ControllerBase
    {
        private readonly ILogger<ProductSubCategoryController> _logger;
        private readonly IMediator _mediator;
        private readonly IProductSubCategoryRepo _productSubCategoryRepo;
        public ProductSubCategoryController(ILogger<ProductSubCategoryController> logger, IMediator mediator, IProductSubCategoryRepo productSubCategoryRepo)
        {
            _logger = logger;
            _mediator = mediator;
            _productSubCategoryRepo = productSubCategoryRepo;
        }

        [HttpPost]
        [Route("AddSubProductCategory")]
        public async Task<ActionResult> CreateProductCategory(CreateSubCategoryCommand createSubCategoryCommand)
        {
            _logger.LogInformation("Adding SubCategory initiated");
            var response = await _mediator.Send(createSubCategoryCommand);
            if (response == null)
            {
                return BadRequest();
            }
            _logger.LogInformation("Adding SubCategory completed");
            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllSubCategories")]
        public async Task<IActionResult> GetAllSubCategory()
        {
            _logger.LogInformation("SubCategory list initiated");
            var roleList = await _mediator.Send(new GetCategoryQuery());
            _logger.LogInformation("SubCategory list completed");
            return Ok(roleList);
        }


        [HttpGet]
        [Route("GetSubCategoryById")]
        public async Task<IActionResult> GetSubCategoryById(int id)
        {
            _logger.LogInformation("Get SubCategory initiated");
            var response = await _mediator.Send(new GetSubCategoryByIdQuery() { Id = id });
            _logger.LogInformation("Get SubCategory completed");
            return Ok(response);
        }

        [HttpGet]
        [Route("GetSubCategoryByCategoryId/{id}")]
        public async Task<IActionResult> GetSubCategoryByCategoryId(int id)
        {
            _logger.LogInformation("Get SubCategory initiated");
            var response = await _mediator.Send(new GetSubCategoryByCategoryIdQuery() { CategoryId = id });
            _logger.LogInformation("Get SubCategory completed");
            return Ok(response);
        }


        //Update SubCategory
        [HttpPost]
        [Route("UpdateSubCategory")]
        public async Task<ActionResult> UpdateSubCategory([FromBody] UpdateSubCategoryCommand updateSubCategoryCommand)
        {
            _logger.LogInformation("Update Sub Category initiated");
            var response = await _mediator.Send(updateSubCategoryCommand);
            _logger.LogInformation("Upadte Sub Category completed");
            return Ok(response);
        }

        [HttpPost]
        [Route("SubCategoryExist")]
        public async Task<ActionResult> SubCategoryExist(SubCategoryExistCommand subCategoryExistCommand)
        {
            _logger.LogInformation("SubCategoryExist Initiated");
            var response=await _mediator.Send(subCategoryExistCommand);
            _logger.LogInformation("SubCategoryExist Completed");
            return Ok(response);
        }



        [HttpDelete]
        [Route("DeleteSubCategory")]
        public async Task<ActionResult> DeleteSubCategory(int Id, int? deletedBy)
        {
            _logger.LogInformation("Remove SubCategory Initiated");
            var dtos = await _mediator.Send(new DeleteSubCategoryCommand() { SubCategoryId = Id ,DeletedBy = deletedBy});
            _logger.LogInformation("Remove User Completed");
            return Ok(dtos);
        }


        [HttpGet]
        [Route("ToggleActiveStatus")]
        public async Task<ActionResult> ToggleActiveStatus(int id)
        {
            bool isActive = await _productSubCategoryRepo.ToggleActiveStatus(id);
            return (isActive) ? Ok("Active") : Ok("InActive");
        }

    }
}
