using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Stocks.Queries.GetStockByStockId
{
    public class GetStockByStockIdQueryHandler : IRequestHandler<GetStockByStockIdQuery, Response<GetStockByStockIdVm>>
    {
        private readonly ILogger<GetStockByStockIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;

        public GetStockByStockIdQueryHandler(ILogger<GetStockByStockIdQueryHandler> _logger, IMapper _mapper, IStockRepository _stockRepository)
        {
            this._logger = _logger;
            this._mapper = _mapper;
            this._stockRepository = _stockRepository;
        }

        public async Task<Response<GetStockByStockIdVm>> Handle(GetStockByStockIdQuery request, CancellationToken cancellationToken)
        {
            var stockData = await _stockRepository.GetByIdAsync(request.StockId);
            if (stockData is not null)
            {
                var stockVm = _mapper.Map<GetStockByStockIdVm>(stockData);
                return new Response<GetStockByStockIdVm>() { Data = stockVm, Succeeded = true };
            }
            else
            {
                return new Response<GetStockByStockIdVm>() { Errors = new List<string>() { "404", "Not Found", $"Stock having id '{request.StockId}' does not exists." }, Succeeded = false };
            }
        }
    }
}
