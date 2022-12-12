using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.PurchaseCart.Queries.GetTotalBill
{

    public class PurchaseGetTotalBillQueryHandler : IRequestHandler<PurchaseGetTotalBillQuery, PurchaseGetTotalBillQueryVm>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PurchaseGetTotalBillQueryHandler> _logger;
        private readonly IPurchaseCartRepo _purchaseCartRepo;
        public PurchaseGetTotalBillQueryHandler(IMapper mapper, ILogger<PurchaseGetTotalBillQueryHandler> logger, IPurchaseCartRepo purchaseCartRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _purchaseCartRepo = purchaseCartRepo;
        }
        public async Task<PurchaseGetTotalBillQueryVm> Handle(PurchaseGetTotalBillQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("All Total Bill inintiated");

            double TotalBill = 0;
            //var TotalBill = await _cartRepo.GetAllCartBill(request.UserId);
            PurchaseGetTotalBillQueryVm getTotal = new PurchaseGetTotalBillQueryVm();
            var allcart = await _purchaseCartRepo.PurchaseGetAllCart(request.UserId);
            foreach (var cart in allcart)
            {
                TotalBill = (cart.Price * cart.Quantity) + TotalBill;
            }
            getTotal.TotalBill = TotalBill;
            //var cartData = _mapper.Map<List<GetCartListVm>>(allcart);

            _logger.LogInformation("Displayed all cart successfully");


            return getTotal;
        }
    }
}
