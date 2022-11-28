using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.ProductCategory.Commands.CraeteProductCategory;
using Corbet.Application.Features.ProductCategory.Commands.CreateProductCategory;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.AddCart.Command
{

    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, Response<CreateCartCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCartCommandHandler> _logger;
        private readonly ICartRepo _cartRepo;
        public CreateCartCommandHandler(IMapper mapper, ILogger<CreateCartCommandHandler> logger, ICartRepo cartRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _cartRepo = cartRepo;
        }

        public async Task<Response<CreateCartCommandDto>> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {

            var cart = _mapper.Map<Domain.Entities.AddToCart>(request);
            bool check = await _cartRepo.IsCartExist(cart);
            if (check)
            {
                var cartDto = _mapper.Map<CreateCartCommandDto>(cart);
                return new Response<CreateCartCommandDto>(cartDto);
            }
            else
            {
                cart.Quantity = 1;
                var cartData = await _cartRepo.AddAsync(cart);
                var cartDto = _mapper.Map<CreateCartCommandDto>(cartData);
                return new Response<CreateCartCommandDto>(cartDto);
            }
        }
    }
}
  