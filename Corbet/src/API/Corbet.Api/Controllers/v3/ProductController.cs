using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Products.Commands.CreateProduct;
using Corbet.Application.Features.Products.Commands.DeleteProduct;
using Corbet.Application.Features.Products.Commands.UpdateProduct;
using Corbet.Application.Features.Products.Queries.GetAllProducts;
using Corbet.Application.Features.Products.Queries.GetProductById;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        readonly IMediator _mediator;
        readonly ILogger<UserController> _logger;
        readonly IProductRepository _productRepository;

        public ProductController(IMediator mediator, ILogger<UserController> logger, IProductRepository productRepository)
        {
            _mediator = mediator;
            _logger = logger;
            _productRepository = productRepository;
        }


        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult> CreateProduct(CreateProductCommand product)
        {
            _logger.LogInformation("Product add initiated");
            var addProduct = await _mediator.Send(product);
            _logger.LogInformation("Product added");
            return Ok(addProduct);
        }


        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<ActionResult> GetAllProducts()
        {
            _logger.LogInformation("Get Products Initiated");
            var products = await _mediator.Send(new GetAllProductsQuery());
            _logger.LogInformation("Get Products Completed");
            return Ok(products);
        }


        [HttpGet]
        [Route("GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            _logger.LogInformation("Get User Initiated");
            var product = await _mediator.Send(new GetProductByIdQuery() { ProductId = id });
            _logger.LogInformation("Get User Completed");
            return Ok(product);
        }


        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateProductCommand product)
        {
            _logger.LogInformation("Update Product Initiated");
            var response = await _mediator.Send(product);
            _logger.LogInformation("Update Product Completed");
            return Ok(response);
        }


        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<ActionResult> DeleteProduct(int Id)
        {
            _logger.LogInformation("Remove Product Initiated");
            var dtos = await _mediator.Send(new DeleteProductCommand() { Id = Id });
            _logger.LogInformation("Remove Product Completed");
            return Ok(dtos);
        }
    }
}
