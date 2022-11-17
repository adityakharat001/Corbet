using Corbet.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace Corbet.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
