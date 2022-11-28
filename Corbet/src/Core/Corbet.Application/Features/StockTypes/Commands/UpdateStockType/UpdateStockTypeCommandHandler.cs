using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.StockTypes.Commands.UpdateStockType
{
    public class UpdateStockTypeCommandHandler : IRequestHandler<UpdateStockTypeCommand, Response<UpdateStockTypeDto>>
    {
        private readonly ILogger<UpdateStockTypeCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStockTypeRepository _stockTypeRepository;

        public UpdateStockTypeCommandHandler(ILogger<UpdateStockTypeCommandHandler> _logger, IMapper _mapper, IStockTypeRepository _stockTypeRepository)
        {
            this._logger = _logger;
            this._mapper = _mapper;
            this._stockTypeRepository = _stockTypeRepository;
        }

        public async Task<Response<UpdateStockTypeDto>> Handle(UpdateStockTypeCommand request, CancellationToken cancellationToken)
        {
            var stockType = _mapper.Map<StockType>(request);
            var stockTypeData = await _stockTypeRepository.GetByIdAsync(request.StockTypeId);
            if (stockTypeData is not null)
            {
                stockTypeData = _mapper.Map<StockType>(request);
                await _stockTypeRepository.UpdateAsync(stockTypeData);
                var stockTypeDto = _mapper.Map<UpdateStockTypeDto>(stockTypeData);
                return new Response<UpdateStockTypeDto>() { Data = stockTypeDto, Succeeded = true };
            }
            else
            {
                return new Response<UpdateStockTypeDto>() { Errors = new List<string>() { "404", "Not Found", "Doesn't Exists." }, Succeeded = false };
            }
        }
    }
}
