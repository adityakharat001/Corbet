using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.UnitMeasurements.Queries.GetAllUnitMeasurements;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.UnitMeasurements.Queries.GetAllUnitMeasurementss
{
    public class GetAllUnitMeasurementsQueryHandler : IRequestHandler<GetAllUnitMeasurementsQuery, List<GetAllUnitMeasurementsVm>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitMeasurementRepository _unitMeasurementRepository;
        private readonly ILogger<GetAllUnitMeasurementsQueryHandler> _logger;

        public GetAllUnitMeasurementsQueryHandler(ILogger<GetAllUnitMeasurementsQueryHandler> logger, IMapper mapper, IUnitMeasurementRepository _unitMeasurementRepository)
        {
            _logger = logger;
            _mapper = mapper;
            this._unitMeasurementRepository = _unitMeasurementRepository;
        }
        public async Task<List<GetAllUnitMeasurementsVm>> Handle(GetAllUnitMeasurementsQuery request, CancellationToken cancellationToken)
        {
            var unitMeasurements = await _unitMeasurementRepository.ListAllAsyncAddOn();
            var unitMeasurementsVm = _mapper.Map<List<GetAllUnitMeasurementsVm>>(unitMeasurements);
            return unitMeasurementsVm;
        }
    }
}
