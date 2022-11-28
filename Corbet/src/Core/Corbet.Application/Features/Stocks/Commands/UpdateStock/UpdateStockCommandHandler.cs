using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Stocks.Commands.UpdateStock
{
    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand, Response<UpdateStockDto>>
    {
        private readonly ILogger<UpdateStockCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;

        public UpdateStockCommandHandler(ILogger<UpdateStockCommandHandler> _logger, IMapper _mapper, IStockRepository _stockRepository)
        {
            this._logger = _logger;
            this._mapper = _mapper;
            this._stockRepository = _stockRepository;
        }

        public async Task<Response<UpdateStockDto>> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            var stock = _mapper.Map<Stock>(request);
            var stockData = await _stockRepository.GetByIdAsync(request.StockId);
            if (stockData is not null)
            {
                stockData = _mapper.Map<Stock>(request);
                await _stockRepository.UpdateAsync(stockData);
                var stockDto = _mapper.Map<UpdateStockDto>(stockData);
                return new Response<UpdateStockDto>() { Data = stockDto, Succeeded = true };
            }
            else
            {
                return new Response<UpdateStockDto>() { Errors = new List<string>() { "404", "Not Found", "Doesn't Exists." }, Succeeded = false };
            }
        }
    }
}
