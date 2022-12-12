using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.PurchaseCart.Queries.GetAllOrder
{
    

      public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<GetAllOrderQueryVm>>
   {
        private readonly IMapper _mapper;
    private readonly ILogger<GetAllOrderQueryHandler> _logger;
        private readonly IPurchaseOrderManagement _orderManagementRepo;
        public GetAllOrderQueryHandler(IMapper mapper, ILogger<GetAllOrderQueryHandler> logger, IPurchaseOrderManagement orderManagementRepo)
    {
        _mapper = mapper;
        _logger = logger;
            _orderManagementRepo = orderManagementRepo;
        }

    public async Task<List<GetAllOrderQueryVm>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("All Order inintiated");

            var allOrder = await _orderManagementRepo.GetAllOrder(request.UserId);

            //   var orderData = _mapper.Map<List<GetAllOrderQueryVm>>(allOrder);

            _logger.LogInformation("Displayed all Order successfully");

        return new List<GetAllOrderQueryVm>(allOrder);
    }
}
    }


