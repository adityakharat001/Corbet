using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.AddCart.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.PurchaseCart.Queries.GetAllCart
{
    

    public class PurchaseGetAllCartQueryHandler : IRequestHandler<PurchaseGetAllCartQuery, List<PurchaseGetAllCartQueryVm>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PurchaseGetAllCartQueryHandler> _logger;
        private readonly IPurchaseCartRepo _purchaseCartRepo;
        public PurchaseGetAllCartQueryHandler(IMapper mapper, ILogger<PurchaseGetAllCartQueryHandler> logger, IPurchaseCartRepo purchaseCartRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _purchaseCartRepo = purchaseCartRepo;
        }
        public async Task<List<PurchaseGetAllCartQueryVm>> Handle(PurchaseGetAllCartQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("All Cart List inintiated");

            var allcart = await _purchaseCartRepo.PurchaseGetAllCart(request.userId);

            //var cartData = _mapper.Map<List<GetCartListVm>>(allcart);

            _logger.LogInformation("Displayed all cart successfully");

            return new List<PurchaseGetAllCartQueryVm>(allcart);
        }
    }
}

