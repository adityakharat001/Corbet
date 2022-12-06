using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.AddCart.Command.DecreaseCartItem
{

    public class IncreaseCartItemCommandHandler : IRequestHandler<IncreaseCartItemCommand, IncreaseCartItemCommandDto>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<IncreaseCartItemCommandHandler> _logger;
        private readonly ICartRepo _cartRepo;
        public IncreaseCartItemCommandHandler(IMapper mapper, ILogger<IncreaseCartItemCommandHandler> logger, ICartRepo cartRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _cartRepo = cartRepo;
        }

        public async Task<IncreaseCartItemCommandDto> Handle(IncreaseCartItemCommand request, CancellationToken cancellationToken)
        {

            bool check = _cartRepo.IncreaseCartitem(request.CartId, request.UserId, request.stockId, request.productId, request.Quantity);
            if (check)
            {

                IncreaseCartItemCommandDto decreaseCart = new IncreaseCartItemCommandDto();
                decreaseCart.Success = true;
                return decreaseCart;
            }
            else
            {
                IncreaseCartItemCommandDto decreaseCart = new IncreaseCartItemCommandDto();
                decreaseCart.Success = false;
                return decreaseCart;
            }
        }
    }
    }
