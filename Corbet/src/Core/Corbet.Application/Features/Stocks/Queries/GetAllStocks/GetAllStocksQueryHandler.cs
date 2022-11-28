using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Stocks.Queries.GetAllStocks
{
    public class GetAllStocksQueryHandler : IRequestHandler<GetAllStocksQuery, Response<List<GetAllStocksVmOut>>>
    {
        private readonly ILogger<GetAllStocksQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStockTypeRepository _stockTypeRepository;

        public GetAllStocksQueryHandler(ILogger<GetAllStocksQueryHandler> _logger, IMapper _mapper, IStockRepository _stockRepository, IProductRepository _productRepository, IStockTypeRepository _stockTypeRepository)
        {
            this._logger = _logger;
            this._mapper = _mapper;
            this._stockRepository = _stockRepository;
            this._productRepository = _productRepository;
            this._stockTypeRepository = _stockTypeRepository;
        }

        public async Task<Response<List<GetAllStocksVmOut>>> Handle(GetAllStocksQuery request, CancellationToken cancellationToken)
        {
            var stockList = await _stockRepository.ListAllAsync();
            var stockListVm = _mapper.Map<List<GetAllStocksVm>>(stockList);
            foreach(var stock in stockListVm)
            {
                stock.ProductName = _productRepository.GetByIdAsync(stock.ProductId).Result.ProductName;
                stock.StockTypeName = _stockTypeRepository.GetByIdAsync(stock.StockTypeId).Result.StockTypeName;
            }
            var stockListVmOut = _mapper.Map<List<GetAllStocksVmOut>>(stockListVm);
            return new Response<List<GetAllStocksVmOut>>() { Data = stockListVmOut, Succeeded = true };
        }
    }
}
