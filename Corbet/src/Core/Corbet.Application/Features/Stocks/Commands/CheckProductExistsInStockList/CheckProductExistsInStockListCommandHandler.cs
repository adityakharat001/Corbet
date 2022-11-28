using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.Products.Commands.CheckProductExistsInStockList
{
    public class CheckProductExistsInStockListCommandHandler : IRequestHandler<CheckProductExistsInStockListCommand, Response<bool>>
    {
        private readonly ILogger<CheckProductExistsInStockListCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;

        public CheckProductExistsInStockListCommandHandler(ILogger<CheckProductExistsInStockListCommandHandler> _logger, IMapper _mapper, IStockRepository _stockRepository)
        {
            this._logger = _logger;
            this._mapper = _mapper;
            this._stockRepository = _stockRepository;
        }

        public async Task<Response<bool>> Handle(CheckProductExistsInStockListCommand request, CancellationToken cancellationToken)
        {
            var isProductExists = await _stockRepository.CheckProductExistsInStockList(request.ProductId);
            return new Response<bool>() { Data = isProductExists, Succeeded = isProductExists };
        }
    }
}
