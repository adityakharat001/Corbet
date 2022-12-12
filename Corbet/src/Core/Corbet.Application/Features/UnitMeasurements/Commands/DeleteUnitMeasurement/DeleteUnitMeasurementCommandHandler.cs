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

namespace Corbet.Application.Features.UnitMeasurements.Commands.DeleteUnitMeasurement
{
    public class DeleteUnitMeasurementCommandHandler : IRequestHandler<DeleteUnitMeasurementCommand, Response<DeleteUnitMeasurementDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitMeasurementRepository _unitMeasurementRepository;

        public DeleteUnitMeasurementCommandHandler(IMapper mapper, IUnitMeasurementRepository _unitMeasurementRepository)
        {
            _mapper = mapper;
            this._unitMeasurementRepository = _unitMeasurementRepository;
        }

        public async Task<Response<DeleteUnitMeasurementDto>> Handle(DeleteUnitMeasurementCommand request, CancellationToken cancellationToken)
        {
            var unitMeasurement = _mapper.Map<UnitMeasurement>(request);
            var unitMeasurementData = await _unitMeasurementRepository.GetById(unitMeasurement.Id);
            if (unitMeasurementData is not null)
            {
                //await _unitMeasurementRepository.DeleteAsync(unitMeasurementData);
                unitMeasurementData.IsDeleted = true;
                await _unitMeasurementRepository.UpdateAsync(unitMeasurementData);
                var unitMeasurementDto = _mapper.Map<DeleteUnitMeasurementDto>(unitMeasurementData);
                return new Response<DeleteUnitMeasurementDto>() { Data = unitMeasurementDto, Succeeded = true };
            }
            else
            {
                return new Response<DeleteUnitMeasurementDto>() { Errors = new List<string>() { "404", "Not Found", "Doesn't Exists." }, Succeeded = false };
            }
        }
    }
}
