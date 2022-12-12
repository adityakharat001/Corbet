using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Corbet.Application.Features.UnitMeasurements.Commands.CreateUnitMeasurement
{
    public class CreateUnitMeasurementCommand : IRequest<Response<CreateUnitMeasurementDto>>
    {

        public string Type { get; set; }
        public int? CreatedBy { get; set; }

    }
}
