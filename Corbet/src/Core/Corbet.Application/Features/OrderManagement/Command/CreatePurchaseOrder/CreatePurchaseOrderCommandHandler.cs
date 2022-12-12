using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Infrastructure;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.PurchaseCart.Queries.GetAllCart;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.OrderManagement.Command.CreatePurchaseOrder
{
    public class CreatePurchaseOrderCommandHandler : IRequestHandler<CreatePurchaseOrderCommand, Response<CreatePurchaseOrderCommandDto>>
    {

        private readonly ILogger<CreatePurchaseOrderCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPurchaseOrderManagement _orderManagementRepo;
        private readonly IOrderAddress _orderAddress;
        private readonly IPurchaseCartRepo _purchaseCartRepo;
        private readonly IEmailService _emailservice;
        public CreatePurchaseOrderCommandHandler(ILogger<CreatePurchaseOrderCommandHandler> logger, IEmailService emailservice, IPurchaseCartRepo purchaseCartRepo, IMapper mapper, IPurchaseOrderManagement orderManagementRepo, IOrderAddress orderAddress)
        {
            _emailservice = emailservice;
            _logger = logger;
            _mapper = mapper;
            _orderManagementRepo = orderManagementRepo;
            _orderAddress = orderAddress;
            _purchaseCartRepo = purchaseCartRepo;
        }


        public async Task<Response<CreatePurchaseOrderCommandDto>> Handle(CreatePurchaseOrderCommand request, CancellationToken cancellationToken)
        {
            var OrderData = _mapper.Map<Domain.Entities.PurchaseOrderManagement>(request);

            CreatePurchaseOrderCommandDto responses = new CreatePurchaseOrderCommandDto();


            List<Domain.Entities.PurchaseCart> addcart = _orderManagementRepo.GetAllCart(request.UserId);

            OrderAddress orderAddress = new OrderAddress();
            orderAddress.City = request.City;
            orderAddress.Address = request.Address;
            orderAddress.StateId = request.StateId;
            orderAddress.ZipCode = request.ZipCode;
            var orderAdd = await _orderAddress.AddAsync(orderAddress);
            if (orderAdd != null)
            {
                OrderData.AddressId = orderAdd.AddressId;
                var OrderDto = await _orderManagementRepo.AddAsync(OrderData);
                var allcart = await _purchaseCartRepo.PurchaseGetAllCart(request.UserId);
                PurchaseGetAllCartQueryVm purchase = new PurchaseGetAllCartQueryVm();


                responses.OrderId = OrderDto.OrderId;
                responses.Message = "Order Detail Added Successful";
                responses.Succeeded = true;
                return new Response<CreatePurchaseOrderCommandDto>(responses, "success");

            }
            else
            {
                responses.Succeeded = false;
                responses.Message = "Order not added";
                responses.OrderId = 0;

                return new Response<CreatePurchaseOrderCommandDto>(responses, "failed");

            }

        }

    }
}
