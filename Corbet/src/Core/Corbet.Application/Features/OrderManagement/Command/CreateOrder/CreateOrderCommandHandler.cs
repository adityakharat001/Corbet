using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.OrderManagement.Command.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreateOrderCommandDto>>
    {

        private readonly ILogger<CreateOrderCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IOrderManagementRepo _orderManagementRepo;
        private readonly IOrderDetailRepo _orderDetailRepo;
        public CreateOrderCommandHandler(ILogger<CreateOrderCommandHandler> logger, IMapper mapper,IOrderDetailRepo orderDetailRepo ,IOrderManagementRepo orderManagementRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _orderManagementRepo = orderManagementRepo;
            _orderDetailRepo = orderDetailRepo;
        }


        public  async Task<Response<CreateOrderCommandDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var OrderData = _mapper.Map<Domain.Entities.OrderManagement>(request);
            var OrderDto =await _orderManagementRepo.AddAsync(OrderData);


            List<AddToCart> addcart = _orderManagementRepo.GetAllCart(request.UserId);
       
            OrderDetail orderDetail = new OrderDetail();
            
            foreach (AddToCart add in addcart)
            {
                orderDetail.SupplierId = request.SupplierId;
                orderDetail.StockId = add.StockingId;
                orderDetail.UserId = add.UserId;
                orderDetail.OrderId = OrderDto.OrderId;
                orderDetail.Quantity = add.Quantity;
                orderDetail.Price = add.Price;
              var value=   _orderDetailRepo.AddAsync(orderDetail);
                //bool check = _orderManagementRepo.(orderDetail);
            }

            CreateOrderCommandDto responses = new CreateOrderCommandDto();
            responses.OrderId = OrderDto.OrderId;
            responses.Message = "Order Detail Added Successful";
            responses.Succeeded = true;
            return new Response<CreateOrderCommandDto>(responses,"success");



        }
        }
    }
