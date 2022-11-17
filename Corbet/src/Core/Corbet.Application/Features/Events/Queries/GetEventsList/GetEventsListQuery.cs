using Corbet.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Corbet.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery: IRequest<Response<IEnumerable<EventListVm>>>
    {

    }
}
