//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using AutoMapper;
//using Corbet.Application.Contracts.Persistence;
//using Corbet.Application.Features.ProductCategory.Commands.CraeteProductCategory;
//using Corbet.Application.Features.ProductCategory.Commands.CreateProductCategory;
//using Corbet.Application.Responses;
//using MediatR;
//using Microsoft.Extensions.Logging;

//namespace Corbet.Application.Features.OrderManagement.Command
//{

//    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreateOrderDto>>
//    {
//        private readonly IMapper _mapper;
//        private readonly ILogger<CreateOrderCommandHandler> _logger;
//        private readonly IOrderManagementRepo _orderManagementRepo;
//        public CreateOrderCommandHandler(IMapper mapper, ILogger<CreateOrderCommandHandler> logger, IOrderManagementRepo orderManagementRepo)
//        {
//            _mapper = mapper;
//            _logger = logger;
//            _orderManagementRepo = orderManagementRepo;
//        }

//        public async Task<Response<CreateOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
//        {
//            var order = _mapper.Map<Domain.Entities.OrderManagement>(request);
//            var orderData = await _orderManagementRepo.AddAsync(order);
//            var orderDto = _mapper.Map<CreateOrderDto>(orderData);
//            return new Response<CreateOrderDto>(orderDto);
//        }
//    }
//}
