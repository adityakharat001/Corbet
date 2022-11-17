using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.UnitMeasurements.Commands.DoesUnitTypeExists
{
    public class DoesUnitTypeExistsCommandHandler : IRequestHandler<DoesUnitTypeExistsCommand, Response<bool>>
    {
        private readonly IUnitMeasurementRepository _unitMeasurementRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DoesUnitTypeExistsCommandHandler> _logger;

        public DoesUnitTypeExistsCommandHandler(IUnitMeasurementRepository _unitMeasurementRepository, IMapper mapper, ILogger<DoesUnitTypeExistsCommandHandler> logger)
        {
            this._unitMeasurementRepository = _unitMeasurementRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> Handle(DoesUnitTypeExistsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("DoesUnitTypeExistsCommand CommandHandler initiated");
            bool emailPresent = await _unitMeasurementRepository.CheckIfUnitTypeAlreadyExists(request.Type);
            _logger.LogInformation("DoesUnitTypeExistsCommand CommandHandler terminated");

            return new Response<bool>(emailPresent);


        }
    }
}
