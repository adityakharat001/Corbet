using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.Stocks.Queries.GetAllStocks;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.AddCart.Queries.GetProductSupplier
{


    public class GetProductSupplierQueryHandler : IRequestHandler<GetProductSupplierListQuery, List<GetProductSupplierQueryVm>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductSupplierQueryHandler> _logger;
        private readonly ICartRepo _cartRepo;
        public GetProductSupplierQueryHandler(IMapper mapper, ILogger<GetProductSupplierQueryHandler> logger, ICartRepo cartRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _cartRepo = cartRepo;
        }
        public async Task<List<GetProductSupplierQueryVm>> Handle(GetProductSupplierListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("All Product Supplier List inintiated");

            var allproductSupplier = await _cartRepo.GetAllProductSupplier();

            //var cartData = _mapper.Map<List<GetCartListVm>>(allcart);

            _logger.LogInformation("Displayed all cart successfully");

            return new List<GetProductSupplierQueryVm>(allproductSupplier);
        }
    
}
}
