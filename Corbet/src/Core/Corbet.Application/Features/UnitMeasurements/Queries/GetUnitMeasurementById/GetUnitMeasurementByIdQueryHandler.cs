using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.UnitMeasurements.Queries.GetUnitMeasurementById
{
    public class GetUnitMeasurementByIdQueryHandler : IRequestHandler<GetUnitMeasurementByIdQuery, Response<GetUnitMeasurementByIdVm>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitMeasurementRepository _unitMeasurementRepository;
        private readonly ILogger<GetUnitMeasurementByIdQueryHandler> _logger;

        public GetUnitMeasurementByIdQueryHandler(ILogger<GetUnitMeasurementByIdQueryHandler> logger, IMapper mapper, IUnitMeasurementRepository _unitMeasurementRepository)
        {
            _logger = logger;
            _mapper = mapper;
            this._unitMeasurementRepository = _unitMeasurementRepository;
        }

        public async Task<Response<GetUnitMeasurementByIdVm>> Handle(GetUnitMeasurementByIdQuery request, CancellationToken cancellationToken)
        {
            var unitMeasurement = _mapper.Map<UnitMeasurement>(request);
            var unitMeasurementData = await _unitMeasurementRepository.GetById(unitMeasurement.Id);
            if (unitMeasurementData is not null)
            {
                var unitMeasurementVm = _mapper.Map<GetUnitMeasurementByIdVm>(unitMeasurementData);
                return new Response<GetUnitMeasurementByIdVm>() { Data = unitMeasurementVm, Succeeded = true };
            }
            else
            {
                return new Response<GetUnitMeasurementByIdVm>() { Errors = new List<string>() { "404", "Not Found", $"UnitMeasuremnt id '{request.id}' does not exists." }, Succeeded = false };
            }
        }
    }
}
