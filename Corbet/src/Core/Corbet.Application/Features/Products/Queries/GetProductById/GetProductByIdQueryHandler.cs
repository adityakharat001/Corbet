using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper; 
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetById(request.ProductId);
            return product;
        }
    }
    
}
