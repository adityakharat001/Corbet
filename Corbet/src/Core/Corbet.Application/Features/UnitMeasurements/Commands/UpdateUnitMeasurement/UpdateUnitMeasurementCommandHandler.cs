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

namespace Corbet.Application.Features.UnitMeasurements.Commands.UpdateUnitMeasurement
{
    public class UpdateUnitMeasurementCommandHandler : IRequestHandler<UpdateUnitMeasurementCommand, Response<UpdateUnitMeasurementDtoOut>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitMeasurementRepository _unitMeasurementRepository;

        public UpdateUnitMeasurementCommandHandler(IMapper mapper, IUnitMeasurementRepository _unitMeasurementRepository)
        {
            _mapper = mapper;
            this._unitMeasurementRepository = _unitMeasurementRepository;
        }
        public async Task<Response<UpdateUnitMeasurementDtoOut>> Handle(UpdateUnitMeasurementCommand request, CancellationToken cancellationToken)
        {
            var unitMeasurement = _mapper.Map<UnitMeasurement>(request.updateUnitMeasurementDtoIn);
            var unitMeasurementData = await _unitMeasurementRepository.GetById(request.id);
            if (unitMeasurementData is not null)
            {
                unitMeasurementData.Type = unitMeasurement.Type;
                await _unitMeasurementRepository.UpdateAsync(unitMeasurementData);
                var unitMeasurementDto = _mapper.Map<UpdateUnitMeasurementDtoOut>(unitMeasurementData);
                return new Response<UpdateUnitMeasurementDtoOut>() { Data = unitMeasurementDto, Succeeded = true };
            }
            else
            {
                return new Response<UpdateUnitMeasurementDtoOut>() { Errors = new List<string>() { "404", "Not Found", "Doesn't Exists." }, Succeeded = false };
            }
        }
    }
}
