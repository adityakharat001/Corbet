using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.PurchaseCart.Command.PurchaseIncrementCart;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.PurchaseCart.Command.PurchaseQuantityUpdate
{
    
    public class PurchaseQuantityUpdateCommandHandler : IRequestHandler<PurchaseQuantityUpdateCommand, PurchaseQuantityUpdateDto>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PurchaseQuantityUpdateCommandHandler> _logger;
        private readonly IPurchaseCartRepo _purchaseCartRepo;
        public PurchaseQuantityUpdateCommandHandler(IMapper mapper, ILogger<PurchaseQuantityUpdateCommandHandler> logger, IPurchaseCartRepo purchaseCartRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _purchaseCartRepo = purchaseCartRepo;
        }

        public async Task<PurchaseQuantityUpdateDto> Handle(PurchaseQuantityUpdateCommand request, CancellationToken cancellationToken)
        {

            bool check = _purchaseCartRepo.QuantityUpdate(request.CartId, request.UserId, request.stockId, request.productId, request.Quantity);
            if (check)
            {

                PurchaseQuantityUpdateDto IncreaseCart = new PurchaseQuantityUpdateDto();
                IncreaseCart.Success = true;
                return IncreaseCart;
            }
            else
            {
                PurchaseQuantityUpdateDto IncreaseCart = new PurchaseQuantityUpdateDto();
                IncreaseCart.Success = false;
                return IncreaseCart;
            }
        }
    }
}
