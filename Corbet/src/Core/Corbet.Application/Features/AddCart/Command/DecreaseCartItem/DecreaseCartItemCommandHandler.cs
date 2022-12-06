using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.AddCart.Command.DecreaseCartItem
{



    public class DecreaseCartItemCommandHandler : IRequestHandler<DecreaseCartItemCommand, DecreaseCartItemCommandDto>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DecreaseCartItemCommandHandler> _logger;
        private readonly ICartRepo _cartRepo;
        public DecreaseCartItemCommandHandler(IMapper mapper, ILogger<DecreaseCartItemCommandHandler> logger, ICartRepo cartRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _cartRepo = cartRepo;
        }

        public async Task<DecreaseCartItemCommandDto> Handle(DecreaseCartItemCommand request, CancellationToken cancellationToken)
        {

            bool check = _cartRepo.DecreaseCartitem(request.CartId, request.UserId, request.stockId, request.productId, request.Quantity);
            if (check)
            {

                DecreaseCartItemCommandDto decreaseCart = new DecreaseCartItemCommandDto();
                decreaseCart.Success = true;
                return decreaseCart;
            }
            else
            {
                DecreaseCartItemCommandDto decreaseCart = new DecreaseCartItemCommandDto();
                decreaseCart.Success = false;
                return decreaseCart;
            }
        }
    }
}