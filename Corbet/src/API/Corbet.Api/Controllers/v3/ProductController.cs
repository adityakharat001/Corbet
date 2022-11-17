using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Products.Commands.CreateProduct;
using Corbet.Application.Features.Products.Queries.GetAllProducts;
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
        public async Task<ActionResult> CreateUser(CreateProductCommand product)
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
    }
}
