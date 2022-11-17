using Corbet.Application.Features.Events.Queries.GetEventsExport;
using Corbet.Infrastructure.FileExport;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace Corbet.Infrastructure.UnitTests.FileExport
{
    public class CsvExporterTests
    {
        [Fact]
        public void ExportEventsToCsv()
        {
            var exporter = new CsvExporter();

            var result = exporter.ExportEventsToCsv(new List<EventExportDto>());

            result.ShouldNotBeNull();
            result.ShouldBeOfType<byte[]>();
        }
    }
}
