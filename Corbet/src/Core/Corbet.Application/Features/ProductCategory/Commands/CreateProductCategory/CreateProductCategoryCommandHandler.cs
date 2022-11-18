using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.ProductCategory.Commands.CraeteProductCategory;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.ProductCategory.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommandHandler:IRequestHandler<CreateProductCategoryCommand, Response<CreateProductCategoryCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCategoryCommandHandler> _logger;
        private readonly IProductCategoryRepo _productCategoryRepo;
        public CreateProductCategoryCommandHandler(IMapper mapper, ILogger<CreateProductCategoryCommandHandler> logger, IProductCategoryRepo productCategoryRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _productCategoryRepo= productCategoryRepo;
        }

        public async Task<Response<CreateProductCategoryCommandDto>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Domain.Entities.ProductCategory>(request);
            var productData = await _productCategoryRepo.AddAsync(category);
            var productDto = _mapper.Map<CreateProductCategoryCommandDto>(productData);
            return new Response<CreateProductCategoryCommandDto>(productDto);
        }
    }
}
