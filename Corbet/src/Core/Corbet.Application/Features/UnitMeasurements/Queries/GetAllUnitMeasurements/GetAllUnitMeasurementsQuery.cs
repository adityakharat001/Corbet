using Corbet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corbet.Application.Features.UnitMeasurements.Queries.GetAllUnitMeasurements
{
    public class GetAllUnitMeasurementsQuery : IRequest<Response<List<GetAllUnitMeasurementsVm>>>
    {
    }
}
