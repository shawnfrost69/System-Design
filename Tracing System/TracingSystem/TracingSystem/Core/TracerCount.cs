namespace TracingSystem.Core;

public class TracerCount
{
    public string TraceId { get; set; }
    public Stack<Span> SoanStack { get; set; }

    public TracerCount(string traceId)
    {
        TraceId = traceId;
    }
}