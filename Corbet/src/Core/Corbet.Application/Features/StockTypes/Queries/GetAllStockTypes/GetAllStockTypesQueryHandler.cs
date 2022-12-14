using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;

using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.StockTypes.Queries.GetAllStockTypes
{
    public class GetAllStockTypesQueryHandler : IRequestHandler<GetAllStockTypesQuery, Response<List<GetAllStockTypesVm>>>
    {
        private readonly ILogger<GetAllStockTypesQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStockTypeRepository _stockTypeRepository;

        public GetAllStockTypesQueryHandler(ILogger<GetAllStockTypesQueryHandler> _logger, IMapper _mapper, IStockTypeRepository _stockTypeRepository)
        {
            this._logger = _logger;
            this._mapper = _mapper;
            this._stockTypeRepository = _stockTypeRepository;
        }

        public async Task<Response<List<GetAllStockTypesVm>>> Handle(GetAllStockTypesQuery request, CancellationToken cancellationToken)
        {
            var stockTypeList = await _stockTypeRepository.ListAllAsyncAddOn();
            var stockTypeListVm = _mapper.Map<List<GetAllStockTypesVm>>(stockTypeList);
            return new Response<List<GetAllStockTypesVm>>() { Data = stockTypeListVm, Succeeded = true };
        }
    }
}
