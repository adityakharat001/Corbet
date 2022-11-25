using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.StockTypes.Queries.GetStockTypeById
{
    public class GetStockTypeByIdQueryHandler : IRequestHandler<GetStockTypeByIdQuery, Response<GetStockTypeByIdVm>>
    {
        private readonly ILogger<GetStockTypeByIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStockTypeRepository _stockTypeRepository;

        public GetStockTypeByIdQueryHandler(ILogger<GetStockTypeByIdQueryHandler> _logger, IMapper _mapper, IStockTypeRepository _stockTypeRepository)
        {
            this._logger = _logger;
            this._mapper = _mapper;
            this._stockTypeRepository = _stockTypeRepository;
        }

        public async Task<Response<GetStockTypeByIdVm>> Handle(GetStockTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var stockTypeData = await _stockTypeRepository.GetByIdAsync(request.StockTypeId);
            if (stockTypeData is not null)
            {
                var stockTypeVm = _mapper.Map<GetStockTypeByIdVm>(stockTypeData);
                return new Response<GetStockTypeByIdVm>() { Data = stockTypeVm, Succeeded = true };
            }
            else
            {
                return new Response<GetStockTypeByIdVm>() { Errors = new List<string>() { "404", "Not Found", $"StockType having id '{request.StockTypeId}' does not exists." }, Succeeded = false };
            }
        }
    }
}
