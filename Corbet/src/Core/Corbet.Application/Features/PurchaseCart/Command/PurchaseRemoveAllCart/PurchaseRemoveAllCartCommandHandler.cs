using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.PurchaseCart.Command.PurchaseRemoveAllCart
{


    public class PurchaseRemoveAllCartCommandHandler : IRequestHandler<PurchaseRemoveAllCartCommand, Response<PurchaseRemoveAllCartCommandDto>>
    {
        private readonly IPurchaseCartRepo _purchaseCartRepo;
        private readonly ILogger<PurchaseRemoveAllCartCommandHandler> _logger;


        public PurchaseRemoveAllCartCommandHandler(IPurchaseCartRepo purchaseCartRepo, ILogger<PurchaseRemoveAllCartCommandHandler> logger)
        {
            _purchaseCartRepo = purchaseCartRepo;
            _logger = logger;
        }

        public async Task<Response<PurchaseRemoveAllCartCommandDto>> Handle(PurchaseRemoveAllCartCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Delete Cart Initiated");
            var cartDto = await _purchaseCartRepo.RemoveAllCartAsync(request.UserId);
            _logger.LogInformation("Delete Cart Completed");
            if (cartDto.Succeeded)
            {
                //mapper.Map<DeleteCommandDto>(userdto);
                return new Response<PurchaseRemoveAllCartCommandDto>(cartDto, "Success");
            }
            else
            {
                var res = new Response<PurchaseRemoveAllCartCommandDto>(cartDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();

        }
    }


}
