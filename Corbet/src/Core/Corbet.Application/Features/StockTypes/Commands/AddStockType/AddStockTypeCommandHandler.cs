using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.StockTypes.Commands.AddStockType
{
    public class AddStockTypeCommandHandler : IRequestHandler<AddStockTypeCommand, Response<AddStockTypeDto>>
    {
        private readonly ILogger<AddStockTypeCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStockTypeRepository _stockTypeRepository;

        public AddStockTypeCommandHandler(ILogger<AddStockTypeCommandHandler> _logger, IMapper _mapper, IStockTypeRepository _stockTypeRepository)
        {
            this._logger = _logger;
            this._mapper = _mapper;
            this._stockTypeRepository = _stockTypeRepository;
        }
        public async Task<Response<AddStockTypeDto>> Handle(AddStockTypeCommand request, CancellationToken cancellationToken)
        {
            var stockType = _mapper.Map<StockType>(request);
            var stockTypeData = await _stockTypeRepository.GetByTypeAsync(request.StockTypeName);
            if (stockTypeData is null)
            {
                var addStockType = await _stockTypeRepository.AddAsync(stockType);
                var addStockTypeDto = _mapper.Map<AddStockTypeDto>(addStockType);
                return new Response<AddStockTypeDto>() { Data = addStockTypeDto, Succeeded = true };
            }
            else
            {
                return new Response<AddStockTypeDto>() { Succeeded = false, Errors = new List<string>() { "409", "Conflict", "StockType Already Exists!" } };
            }
        }
    }
}
