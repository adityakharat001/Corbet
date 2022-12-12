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

namespace Corbet.Application.Features.OrderManagement.Command.UpdatePurchaseOrder
{
    public class UpdatePurchaseOrderStatusCommandHandler : IRequestHandler<UpdatePurchaseOrderStatusCommand, Response<UpdatePurchaseOrderCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePurchaseOrderStatusCommandHandler> _logger;
        private readonly IPurchaseOrderManagement _purchaseOrderManagement;

        public UpdatePurchaseOrderStatusCommandHandler(IMapper mapper, ILogger<UpdatePurchaseOrderStatusCommandHandler> logger, IPurchaseOrderManagement purchaseOrderManagement)
        {
            _mapper = mapper;
            _logger = logger;
            _purchaseOrderManagement = purchaseOrderManagement;

        }

        public async Task<Response<UpdatePurchaseOrderCommandDto>> Handle(UpdatePurchaseOrderStatusCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Delete User Initiated");
            UpdatePurchaseOrderCommandDto updateStockQuantityDto = new UpdatePurchaseOrderCommandDto();
            //  List<AddToCart> addCarts =
            bool cartdto = await _purchaseOrderManagement.UpdateStatus(request.UserId, request.Status);
            _logger.LogInformation("Delete User Completed");

            if (cartdto)
            {
                updateStockQuantityDto.Succeed = true;
                updateStockQuantityDto.Message = "Update Successfull";
                return new Response<UpdatePurchaseOrderCommandDto>(updateStockQuantityDto, "Success");
            }
            else
            {
                var res = new Response<UpdatePurchaseOrderCommandDto>(updateStockQuantityDto, "Failed");
                res.Succeeded = false;
                return res;
            }


            throw new NotImplementedException();


        }
    }
}
