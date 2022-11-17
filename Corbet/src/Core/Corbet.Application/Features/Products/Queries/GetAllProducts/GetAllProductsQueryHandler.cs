using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsVm>>
    {
        private readonly ILogger<GetAllProductsQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(ILogger<GetAllProductsQueryHandler> logger, IMapper mapper, IProductRepository productRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<List<GetAllProductsVm>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Products list Initiated");
            var productList = await _productRepository.GetAllProducts();

            // all employee data and Vm datat match or not
            var productData = _mapper.Map<List<GetAllProductsVm>>(productList);

            _logger.LogInformation("Products list completed");

            return new List<GetAllProductsVm>(productData);
        }
    }
}
