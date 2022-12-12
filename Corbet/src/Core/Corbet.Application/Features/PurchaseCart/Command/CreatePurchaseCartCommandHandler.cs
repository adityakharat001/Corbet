using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.AddCart.Command;
using Corbet.Application.Features.PurchaseCart.Queries.GetAllCart;
using Corbet.Application.Models.Mail;
using Corbet.Application.Responses;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.PurchaseCart.Command
{


    public class CreatePurchaseCartCommandHandler : IRequestHandler<CreatePurchaseCartCommand, Response<CreatePurchaseCartDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePurchaseCartCommandHandler> _logger;
        private readonly IPurchaseCartRepo _purchaseCartRepo;

        public CreatePurchaseCartCommandHandler(IMapper mapper, ILogger<CreatePurchaseCartCommandHandler> logger, IPurchaseCartRepo purchaseCartRepo)
        {
            _mapper = mapper;
            _logger = logger;
            _purchaseCartRepo = purchaseCartRepo;
        }

        public async Task<Response<CreatePurchaseCartDto>> Handle(CreatePurchaseCartCommand request, CancellationToken cancellationToken)
        {
            CreatePurchaseCartDto createPurchaseCartDto = new CreatePurchaseCartDto();
            var cart = _mapper.Map<Domain.Entities.PurchaseCart>(request);
            bool check = await _purchaseCartRepo.IsCartExist(cart);
            //Get All Purchase Cart Data


            if (check)
            {
                cart.Quantity = 1;
                var cartData = await _purchaseCartRepo.AddAsync(cart);

                return new Response<CreatePurchaseCartDto>(createPurchaseCartDto);
            }

            else
            {
                
                

                createPurchaseCartDto.Succeed = true;
                createPurchaseCartDto.Message = "Item Added in cart";

                return new Response<CreatePurchaseCartDto>(createPurchaseCartDto);

            }

        }
    }
}
