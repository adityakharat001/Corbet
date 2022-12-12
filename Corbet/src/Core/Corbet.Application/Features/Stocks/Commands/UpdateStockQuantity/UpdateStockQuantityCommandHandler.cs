using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.AddCart.Queries;
using Corbet.Application.Features.PurchaseCart.Queries.GetAllCart;
using Corbet.Application.Features.Taxes.Commands.DeleteTaxDetail;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;

using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Stocks.Commands.UpdateStockQuantity
{
  
    public class UpdateStockQuantityCommandHandler : IRequestHandler<UpdateStockQuantityCommand, Response<UpdateStockQuantityDto>>
        {
            private readonly IMapper _mapper;
            private readonly ILogger<UpdateStockQuantityCommandHandler> _logger;
        private readonly IStockRepository _stockRepository;
        private readonly IPurchaseCartRepo _purchaseCartRepo;
        public UpdateStockQuantityCommandHandler(IMapper mapper, ILogger<UpdateStockQuantityCommandHandler> logger, IStockRepository stockRepository, IPurchaseCartRepo purchaseCartRepo)
            {
                _mapper = mapper;
                _logger = logger;
            _stockRepository = stockRepository;
            _purchaseCartRepo = purchaseCartRepo;
            }

            public async Task<Response<UpdateStockQuantityDto>> Handle(UpdateStockQuantityCommand request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Delete User Initiated");
            UpdateStockQuantityDto updateStockQuantityDto = new UpdateStockQuantityDto();
           //  List<AddToCart> addCarts =
           List<PurchaseGetAllCartQueryVm> allcart = await _purchaseCartRepo.PurchaseGetAllCart(request.UserId);
            bool cartdto = await _stockRepository.UpdateStockQuantity(allcart);
                _logger.LogInformation("Delete User Completed");

                if (cartdto)
                {
                updateStockQuantityDto.Succeeded = true;
                    updateStockQuantityDto.Message="Update Successfull";
                    return new Response<UpdateStockQuantityDto>(updateStockQuantityDto, "Success");
                }
                else
                {
                    var res = new Response<UpdateStockQuantityDto>(updateStockQuantityDto, "Failed");
                    res.Succeeded = false;
                    return res;
                }


                throw new NotImplementedException();


            }
        }
    }

