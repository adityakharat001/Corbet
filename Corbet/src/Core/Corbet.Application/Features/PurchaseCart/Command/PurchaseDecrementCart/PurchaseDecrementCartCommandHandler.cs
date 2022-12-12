using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.PurchaseCart.Command.PurchaseDecrementCart
{
    

    public class PurchaseDecrementCartCommandHandler : IRequestHandler<PurchaseDecrementCartCommand, PurchaseDecrementCartDto>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PurchaseDecrementCartCommandHandler> _logger;
        private readonly IPurchaseCartRepo _purchaseCartRepo;
        public PurchaseDecrementCartCommandHandler(IMapper mapper, ILogger<PurchaseDecrementCartCommandHandler> logger, IPurchaseCartRepo purchaseCartRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _purchaseCartRepo = purchaseCartRepo;
        }

        public async Task<PurchaseDecrementCartDto> Handle(PurchaseDecrementCartCommand request, CancellationToken cancellationToken)
        {

            bool check = _purchaseCartRepo.DecreaseCartitem(request.CartId, request.UserId, request.stockId, request.productId, request.Quantity);
            if (check)
            {

                PurchaseDecrementCartDto decreaseCart = new PurchaseDecrementCartDto();
                decreaseCart.Success = true;
                return decreaseCart;
            }
            else
            {
                PurchaseDecrementCartDto decreaseCart = new PurchaseDecrementCartDto();
                decreaseCart.Success = false;
                return decreaseCart;
            }
        }
    }
}
