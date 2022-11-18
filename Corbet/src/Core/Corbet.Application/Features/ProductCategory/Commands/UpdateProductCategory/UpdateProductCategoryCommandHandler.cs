using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Exceptions;
using Corbet.Application.Features.Roles.Commands.UpdateRole;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.ProductCategory.Commands.UpdateProductCategory
{
    public class UpdateProductCategoryCommandHandler:IRequestHandler<UpdateProductCategoryCommand, Response<UpdateProductCategoryCommandDto>>
    {
        private readonly ILogger<UpdateProductCategoryCommandHandler> _logger;
        private readonly IProductCategoryRepo _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductCategoryCommandHandler(ILogger<UpdateProductCategoryCommandHandler> logger, IProductCategoryRepo productRepository, IMapper mapper)
        {
            _logger = logger;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Response<UpdateProductCategoryCommandDto>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Update Category initiated");
            var category = await _productRepository.GetById(request.CategoryId);
            if (category == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.ProductCategory), request.CategoryId);
            }

            var categoryData = _mapper.Map(request, category);
            await _productRepository.UpdateAsync(categoryData);
            var categoryDto = _mapper.Map<UpdateProductCategoryCommandDto>(categoryData);
            _logger.LogInformation("Update Category completed");
            return new Response<UpdateProductCategoryCommandDto>(categoryDto);
        }
    }
}
