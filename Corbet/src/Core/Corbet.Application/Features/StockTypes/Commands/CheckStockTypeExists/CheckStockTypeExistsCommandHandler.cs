using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;

using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.StockTypes.Commands.CheckStockTypeExists
{
    public class CheckStockTypeExistsCommandHandler : IRequestHandler<CheckStockTypeExistsCommand, Response<bool>>
    {
        private readonly ILogger<CheckStockTypeExistsCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStockTypeRepository _stockTypeRepository;

        public CheckStockTypeExistsCommandHandler(ILogger<CheckStockTypeExistsCommandHandler> _logger, IMapper _mapper, IStockTypeRepository _stockTypeRepository)
        {
            this._logger = _logger;
            this._mapper = _mapper;
            this._stockTypeRepository = _stockTypeRepository;
        }
        public async Task<Response<bool>> Handle(CheckStockTypeExistsCommand request, CancellationToken cancellationToken)
        {
            var isStockTypeExists = await _stockTypeRepository.CheckStockTypeExists(request.StockTypeName);
            return new Response<bool>() { Data = isStockTypeExists, Succeeded = isStockTypeExists };
        }
    }
}
