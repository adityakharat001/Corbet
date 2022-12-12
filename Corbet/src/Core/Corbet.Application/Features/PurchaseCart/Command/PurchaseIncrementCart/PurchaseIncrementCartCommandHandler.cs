using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.PurchaseCart.Command.PurchaseIncrementCart
{

    public class PurchaseIncrementCartCommandHandler : IRequestHandler<PurchaseIncrementCartCommand, PurchaseIncrementCartDto>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PurchaseIncrementCartCommandHandler> _logger;
        private readonly IPurchaseCartRepo _purchaseCartRepo;
        public PurchaseIncrementCartCommandHandler(IMapper mapper, ILogger<PurchaseIncrementCartCommandHandler> logger, IPurchaseCartRepo purchaseCartRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _purchaseCartRepo = purchaseCartRepo;
        }

        public async Task<PurchaseIncrementCartDto> Handle(PurchaseIncrementCartCommand request, CancellationToken cancellationToken)
        {

            bool check = _purchaseCartRepo.IncreaseCartitem(request.CartId, request.UserId, request.stockId, request.productId, request.Quantity);
            if (check)
            {

                PurchaseIncrementCartDto IncreaseCart = new PurchaseIncrementCartDto();
                IncreaseCart.Success = true;
                return IncreaseCart;
            }
            else
            {
                PurchaseIncrementCartDto IncreaseCart = new PurchaseIncrementCartDto();
                IncreaseCart.Success = false;
                return IncreaseCart;
            }
        }
    }
}