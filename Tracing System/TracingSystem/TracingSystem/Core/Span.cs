namespace TracingSystem.Core;

public class Span
{
    public string SpanId { get; }
    public string TraceId { get; }
    public string OperationName { get; }
    public DateTime StartTime { get; }
    public DateTime? EndTime { get; set; }
    public List<Span> Children { get; }
}