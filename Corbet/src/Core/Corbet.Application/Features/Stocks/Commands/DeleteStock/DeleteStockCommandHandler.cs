using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Stocks.Commands.DeleteStock
{
    public class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommand, Response<DeleteStockDto>>
    {
        private readonly ILogger<DeleteStockCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;

        public DeleteStockCommandHandler(ILogger<DeleteStockCommandHandler> _logger, IMapper _mapper, IStockRepository _stockRepository)
        {
            this._logger = _logger;
            this._mapper = _mapper;
            this._stockRepository = _stockRepository;
        }

        public async Task<Response<DeleteStockDto>> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            var stock = _mapper.Map<Stock>(request);
            var stockData = await _stockRepository.GetByIdAsync(stock.StockId);
            if (stockData is not null)
            {
                //await _stockRepository.DeleteAsync(stockData);
                stockData.IsDeleted = true;
                await _stockRepository.UpdateAsync(stockData);
                var stockDto = _mapper.Map<DeleteStockDto>(stockData);
                return new Response<DeleteStockDto>() { Data = stockDto, Succeeded = true };
            }
            else
            {
                return new Response<DeleteStockDto>() { Errors = new List<string>() { "404", "Not Found", "Doesn't Exists." }, Succeeded = false };
            }
        }
    }
}
