using AutoMapper;
using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.UnitMeasurements.Commands.CreateUnitMeasurement
{
    public class CreateUnitMeasurementCommandHandler : IRequestHandler<CreateUnitMeasurementCommand, Response<CreateUnitMeasurementDto>>
    {
        private readonly IUnitMeasurementRepository _unitMeasurementRepository;
        private readonly IMapper _mapper;
        public CreateUnitMeasurementCommandHandler(IUnitMeasurementRepository unitMeasurementRepository, IMapper mapper)
        {
            _unitMeasurementRepository = unitMeasurementRepository;
            _mapper = mapper;
        }

        public async Task<Response<CreateUnitMeasurementDto>> Handle(CreateUnitMeasurementCommand request, CancellationToken cancellationToken)
        {
            var unitMeasurement = _mapper.Map<UnitMeasurement>(request);
            //var unitMeasurementData = await _unitMeasurementRepository.GetByTypeAsync(unitMeasurement.Type);
            //if (unitMeasurementData is null)
            //{
                var CreateUnitMeasurement = await _unitMeasurementRepository.AddAsync(unitMeasurement);
                var CreateUnitMeasurementDto = _mapper.Map<CreateUnitMeasurementDto>(CreateUnitMeasurement);
                return new Response<CreateUnitMeasurementDto>() { Data = CreateUnitMeasurementDto, Succeeded = true };
            //}
            //else
            //{
            //    return new Response<CreateUnitMeasurementDto>() { Succeeded = false, Errors = new List<string>() { "Already Exists : Conflict" } };
            //}
        }
    }
}
