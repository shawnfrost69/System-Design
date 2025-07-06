using TracingSystem.Models;

namespace TracingSystem.Exporters;

public interface ConsoleExporter : ITraceExporter
{
    public void Export(TraceSpan span)
    {
        Console.WriteLine($"[TraceId: {span.TraceId}] [SpanId: {span.SpanId} Operation: {span.OperationName}]");
        Console.WriteLine($"Start: {span.StartTime}, End: {span.EndTime}, Duration: {(span.EndTime - span.StartTime)?.TotalMilliseconds} ms");

        if (span.Tags.Any())
        {
            Console.WriteLine("Tags:");
            foreach (var tag in span.Tags)
            {
                Console.WriteLine($"{tag.Key}: {tag.Value}");
            }
        }
        Console.WriteLine("------------------------------------------------------");
    }
}