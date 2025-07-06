using TracingSystem.Exporters;
using TracingSystem.Models;

namespace TracingSystem.Core;

public class Tracer
{
    private static readonly AsyncLocal<TracerCount?> _context = new();
    private readonly TraceLogger _logger;

    public Tracer(ITraceExporter exporter)
    {
        _logger = new TraceLogger(exporter);
    }

    public TraceSpan StartSpan(string operationName)
    {
        var context = _context.Value ??= new TracerCount(Guid.NewGuid().ToString());

        var span = new TraceSpan
        {
            TraceId = context.TraceId,
            SpanId = Guid.NewGuid().ToString(),
            OperationName = operationName,
            StartTime = DateTime.UtcNow,
            ParentSpanId = context.SpanStack.Count > 0 ? context.SpanStack.Peek().SpanId : null
        };

        context.SpanStack.Push(span);
        return span;
    }

    public void EndSpan()
    {
        var context = _context.Value;
        if (context == null || context.SpanStack.Count == 0)
            return;

        var span = context.SpanStack.Pop();
        span.EndTime = DateTime.UtcNow;

        _logger.LogSpan(span);

        if (context.SpanStack.Count == 0)
        {
            _context.Value = null;
        }
    }

    public void AddTag(string key, string value)
    {
        var context = _context.Value;
        if (context != null && context.SpanStack.Count > 0)
        {
            var currentSpan = context.SpanStack.Peek();
            currentSpan.Tags[key] = value;
        }
    }
}