using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<UpdateProductCommandDto>>
    {
        private readonly ILogger<UpdateProductCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(ILogger<UpdateProductCommandHandler> logger, IMapper mapper, IProductRepository productRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Response<UpdateProductCommandDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productRepository.GetById(request.ProductId);
            var productData = _mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(Product));
            await _productRepository.UpdateAsync(productToUpdate);
            var productDto = _mapper.Map<UpdateProductCommandDto>(productData);
            return new Response<UpdateProductCommandDto>(productDto);
        }
    }
}
