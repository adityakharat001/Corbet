//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using AutoMapper;
//using Corbet.Application.Contracts.Persistence;
//using Corbet.Application.Features.ProductCategory.Queries.GetAllProductCategories;
//using MediatR;
//using Microsoft.Extensions.Logging;

//namespace Corbet.Application.Features.OrderManagement.Queries
//{
    


//    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<GetOrderListVm>>
//    {
//        private readonly IMapper _mapper;
//        private readonly ILogger<GetOrderListQueryHandler> _logger;
//        private readonly IOrderManagementRepo _orderManagementRepo;
//        public GetOrderListQueryHandler(IMapper mapper, ILogger<GetOrderListQueryHandler> logger, IOrderManagementRepo orderManagementRepo)
//        {
//            _mapper = mapper;
//            _logger = logger;
//            _orderManagementRepo = orderManagementRepo;
//        }

//        public async Task<List<GetOrderListVm>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
//        {
//            _logger.LogInformation("All Order inintiated");

//            var allOrder = await _orderManagementRepo.GetAllOrder();

//            var orderData = _mapper.Map<List<GetOrderListVm>>(allOrder);

//            _logger.LogInformation("Displayed all Order successfully");

//            return new List<GetOrderListVm>(orderData);
//        }
//    }
//}
