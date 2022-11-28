using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.ProductCategory.Queries.GetAllProductCategories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.AddCart.Queries
{
    public class GetCartListQueryHandler : IRequestHandler<GetCartListQuery, List<GetCartListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetCartListQueryHandler> _logger;
        private readonly IOrderManagementRepo _orderManagementRepo;
        public GetCartListQueryHandler(IMapper mapper, ILogger<GetCartListQueryHandler> logger, IOrderManagementRepo orderManagementRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _orderManagementRepo = orderManagementRepo;
        }
        public async Task<List<GetCartListVm>> Handle(GetCartListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("All Cart List inintiated");

            var allcart = await _orderManagementRepo.GetAllCart(request.userId);

            //var cartData = _mapper.Map<List<GetCartListVm>>(allcart);

            _logger.LogInformation("Displayed all cart successfully");

            return new List<GetCartListVm>(allcart);
        }
    }
}

