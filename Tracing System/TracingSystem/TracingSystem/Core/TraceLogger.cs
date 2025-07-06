using TracingSystem.Exporters;
using TracingSystem.Models;

namespace TracingSystem.Core;

public class TraceLogger
{
    private readonly ITraceExporter _exporter;

    public TraceLogger(ITraceExporter exporter)
    {
        _exporter = exporter;
    }

    public void LogSpan(TraceSpan span)
    {
        _exporter.Export(span);
    }
}