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

namespace Corbet.Application.Features.AddCart.Command.RemoveAllCart
{

    public class RemoveAllCartCommandHandler : IRequestHandler<RemoveAllCartCommand, Response<RemoveAllCartCommandDto>>
    {
        private readonly ICartRepo _cartRepository;
        private readonly ILogger<RemoveAllCartCommandHandler> _logger;


        public RemoveAllCartCommandHandler(ICartRepo cartRepository, ILogger<RemoveAllCartCommandHandler> logger)
        {
            _cartRepository = cartRepository;
            _logger = logger;
        }

        public async Task<Response<RemoveAllCartCommandDto>> Handle(RemoveAllCartCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Delete Cart Initiated");
            var cartDto = await _cartRepository.RemoveAllCartAsync(request.UserId);
            _logger.LogInformation("Delete Cart Completed");
            if (cartDto.Succeeded)
            {
                //mapper.Map<DeleteCommandDto>(userdto);
                return new Response<RemoveAllCartCommandDto>(cartDto, "Success");
            }
            else
            {
                var res = new Response<RemoveAllCartCommandDto>(cartDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();

        }


    }
}

