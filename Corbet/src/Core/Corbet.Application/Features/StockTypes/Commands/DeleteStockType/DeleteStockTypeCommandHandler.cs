using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Corbet.Application.Features.StockTypes.Commands.DeleteStockType
{
    public class DeleteStockTypeCommandHandler : IRequestHandler<DeleteStockTypeCommand, Response<DeleteStockTypeDto>>
    {
        private readonly ILogger<DeleteStockTypeCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStockTypeRepository _stockTypeRepository;

        public DeleteStockTypeCommandHandler(ILogger<DeleteStockTypeCommandHandler> _logger, IMapper _mapper, IStockTypeRepository _stockTypeRepository)
        {
            this._logger = _logger;
            this._mapper = _mapper;
            this._stockTypeRepository = _stockTypeRepository;
        }

        public async Task<Response<DeleteStockTypeDto>> Handle(DeleteStockTypeCommand request, CancellationToken cancellationToken)
        {
            var stockType = _mapper.Map<StockType>(request);
            var stockTypeData = await _stockTypeRepository.GetByIdAsync(stockType.StockTypeId);
            if (stockTypeData is not null)
            {
                await _stockTypeRepository.DeleteAsync(stockTypeData);
                var stockTypeDto = _mapper.Map<DeleteStockTypeDto>(stockTypeData);
                return new Response<DeleteStockTypeDto>() { Data = stockTypeDto, Succeeded = true };
            }
            else
            {
                return new Response<DeleteStockTypeDto>() { Errors = new List<string>() { "404", "Not Found", "Doesn't Exists." }, Succeeded = false };
            }
        }
    }
}
