using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.ProductCategory.Commands.DeleteProductCategory;
using Corbet.Application.Features.Roles.Commands.DeleteRole;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.AddCart.Command.DeleteCart
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, Response<DeleteCartCommandDto>>
    {
        private readonly ICartRepo _cartRepository;
        private readonly ILogger<DeleteCartCommandHandler> _logger;


        public DeleteCartCommandHandler(ICartRepo cartRepository, ILogger<DeleteCartCommandHandler> logger)
        {
            _cartRepository = cartRepository;
            _logger = logger;
        }

        public async Task<Response<DeleteCartCommandDto>> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Delete Cart Initiated");
            var cartDto = await _cartRepository.RemoveCartAsync(request.CartId);
            _logger.LogInformation("Delete Cart Completed");
            if (cartDto.Succeeded)
            {
                //mapper.Map<DeleteCommandDto>(userdto);
                return new Response<DeleteCartCommandDto>(cartDto, "Success");
            }
            else
            {
                var res = new Response<DeleteCartCommandDto>(cartDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();
           
        }


    }
}
