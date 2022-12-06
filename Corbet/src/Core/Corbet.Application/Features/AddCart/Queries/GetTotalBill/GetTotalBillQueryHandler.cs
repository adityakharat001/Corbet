using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.AddCart.Queries.GetTotalBill
{


    public class GetTotalBillQueryHandler : IRequestHandler<GetTotalBillQuery, GetTotalBillQueryDto>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetTotalBillQueryHandler> _logger;
        private readonly ICartRepo _cartRepo;
        public GetTotalBillQueryHandler(IMapper mapper, ILogger<GetTotalBillQueryHandler> logger, ICartRepo cartRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _cartRepo = cartRepo;
        }
        public async Task<GetTotalBillQueryDto> Handle(GetTotalBillQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("All Total Bill inintiated");

            double TotalBill = 0;
            //var TotalBill = await _cartRepo.GetAllCartBill(request.UserId);
            GetTotalBillQueryDto getTotal = new GetTotalBillQueryDto();
            var allcart = await _cartRepo.GetAllCart(request.UserId);
            foreach(var cart in allcart)
            {
                TotalBill = (cart.Price*cart.Quantity) + TotalBill;
            }    
            getTotal.TotalBill = TotalBill; 
            //var cartData = _mapper.Map<List<GetCartListVm>>(allcart);

            _logger.LogInformation("Displayed all cart successfully");


            return getTotal;
        }
    }
}