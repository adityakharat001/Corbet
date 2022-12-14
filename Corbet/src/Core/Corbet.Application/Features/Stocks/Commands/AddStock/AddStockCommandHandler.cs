using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Stocks.Commands.AddStock
{
    public class AddStockCommandHandler : IRequestHandler<AddStockCommand, Response<AddStockDto>>
    {
        private readonly ILogger<AddStockCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;

        public AddStockCommandHandler(ILogger<AddStockCommandHandler> _logger, IMapper _mapper, IStockRepository _stockRepository)
        {
            this._logger = _logger;
            this._mapper = _mapper;
            this._stockRepository = _stockRepository;
        }
        public async Task<Response<AddStockDto>> Handle(AddStockCommand request, CancellationToken cancellationToken)
        {
            var stock = _mapper.Map<Stock>(request);
            //var stockData = await _stockRepository.GetByProductIdAsync(request.ProductId);
            //if (stockData is null)
            //{
                var addStock = await _stockRepository.AddAsync(stock);
                var addStockDto = _mapper.Map<AddStockDto>(addStock);
                return new Response<AddStockDto>() { Data = addStockDto, Succeeded = true };
            //}
            //else
            //{
            //    return new Response<AddStockDto>() { Succeeded = false, Errors = new List<string>() { "409", "Conflict", "Stock Already Exists!", "Please select the different product or if you want to update, you can see action buttons on stock listing page." } };
            //}
        }
    }
}
