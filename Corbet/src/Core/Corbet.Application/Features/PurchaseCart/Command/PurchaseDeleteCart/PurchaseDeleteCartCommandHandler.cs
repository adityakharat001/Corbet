using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.AddCart.Command.DeleteCart;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.PurchaseCart.Command.PurchaseDeleteCart
{


    public class PurchaseDeleteCartCommandHandler : IRequestHandler<PurchaseDeleteCartCommand, Response<PurchaseDeleteCartDto>>
    {
        private readonly IPurchaseCartRepo _purchaseCartRepo;
        private readonly ILogger<PurchaseDeleteCartCommandHandler> _logger;


        public PurchaseDeleteCartCommandHandler(IPurchaseCartRepo purchaseCartRepo, ILogger<PurchaseDeleteCartCommandHandler> logger)
        {
            _purchaseCartRepo = purchaseCartRepo;
            _logger = logger;
        }

        public async Task<Response<PurchaseDeleteCartDto>> Handle(PurchaseDeleteCartCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Delete Cart Initiated");
            var cartDto = await _purchaseCartRepo.RemovePurchaseCartAsync(request.CartId);
            _logger.LogInformation("Delete Cart Completed");
            if (cartDto.Succeeded)
            {
                //mapper.Map<DeleteCommandDto>(userdto);
                return new Response<PurchaseDeleteCartDto>(cartDto, "Success");
            }
            else
            {
                var res = new Response<PurchaseDeleteCartDto>(cartDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();

        }


    }

}
