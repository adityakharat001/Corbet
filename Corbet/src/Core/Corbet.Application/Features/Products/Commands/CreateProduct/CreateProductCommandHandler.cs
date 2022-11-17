using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<CreateProductCommandDto>>
    {
        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;


        public CreateProductCommandHandler(ILogger<CreateProductCommandHandler> logger, IMapper mapper, IProductRepository productRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Response<CreateProductCommandDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {


            _logger.LogInformation("Adding Product initiated");
            var product = _mapper.Map<Product>(request);
            var productData = await _productRepository.AddAsync(product);
            var productDto = _mapper.Map<CreateProductCommandDto>(productData);
            _logger.LogInformation("Adding Product Completed");
            return new Response<CreateProductCommandDto>(productDto);

        }
    }
}