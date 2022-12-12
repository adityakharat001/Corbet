using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.UnitMeasurements.Commands.UpdateUnitMeasurement
{
    public class UpdateUnitMeasurementDtoIn
    {
        public string Type { get; set; }
        public int? LastModifiedBy { get; set; }

    }
}
