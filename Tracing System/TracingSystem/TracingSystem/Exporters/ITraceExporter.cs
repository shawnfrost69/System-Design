using TracingSystem.Models;

namespace TracingSystem.Exporters;

public interface ITraceExporter
{
    void Export(TraceSpan span);
}