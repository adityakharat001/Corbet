using Corbet.Application.Contracts.Persistence;
using Corbet.Application.Features.UnitMeasurements.Commands.CreateUnitMeasurement;
using Corbet.Application.Features.UnitMeasurements.Commands.DeleteUnitMeasurement;
using Corbet.Application.Features.UnitMeasurements.Commands.DoesUnitTypeExists;
using Corbet.Application.Features.UnitMeasurements.Commands.UpdateUnitMeasurement;
using Corbet.Application.Features.UnitMeasurements.Queries.GetAllUnitMeasurements;
using Corbet.Application.Features.UnitMeasurements.Queries.GetUnitMeasurementById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corbet.Api.Controllers.v3
{
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UnitMeasurementController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UnitMeasurementController(IMediator mediator)
        {
            _mediator = mediator;
           
        }

        [Route("AddUnitMeasurement")]
        [HttpPost]
        public async Task<IActionResult> AddUnitMeasurement(CreateUnitMeasurementCommand createUnitMeasurementCommand)
        {
            var response = await _mediator.Send(createUnitMeasurementCommand);
            return (response.Succeeded) ? Ok(response) : Conflict(response);
        }

        [Route("DeleteUnitMeasurement/{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUnitMeasurement(int id)
        {
            var response = await _mediator.Send(new DeleteUnitMeasurementCommand(id));
            return (response.Succeeded) ? Ok(response) : NotFound(response);
        }

        [Route("UpdateUnitMeasurement/{id:int}")]
        [HttpPut]
        public async Task<IActionResult> UpdateUnitMeasurement(int id, UpdateUnitMeasurementDtoIn updateUnitMeasurementDtoIn)
        {
            var response = await _mediator.Send(new UpdateUnitMeasurementCommand(id, updateUnitMeasurementDtoIn));
            return (response.Succeeded) ? Ok(response) : NotFound(response);
        }

        [Route("GetAllUnitMeasurements")]
        [HttpGet]
        public async Task<IActionResult> GetAllUnitMeasurements()
        {
            var response = await _mediator.Send(new GetAllUnitMeasurementsQuery());
            return Ok(response);
        }

        [Route("GetUnitMeasurementById")]
        [HttpGet]
        public async Task<IActionResult> GetUnitMeasurementById(int id)
        {
            var response = await _mediator.Send(new GetUnitMeasurementByIdQuery(id));
            return (response.Succeeded) ? Ok(response) : NotFound(response);
        }


        [Route("DoesUnitAlreadyExists/{unitType}")]
        [HttpGet]
        public async Task<IActionResult> DoesUnitAlreadyExists(string unitType)
        {
            var response = await _mediator.Send(new DoesUnitTypeExistsCommand() { Type = unitType });
            return Ok(response);
        }

    }
}
