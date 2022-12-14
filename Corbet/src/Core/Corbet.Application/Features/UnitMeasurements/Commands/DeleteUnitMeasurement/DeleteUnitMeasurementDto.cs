using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.UnitMeasurements.Commands.DeleteUnitMeasurement
{
    public class DeleteUnitMeasurementDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsDeleted { get; set; }
    }
}
