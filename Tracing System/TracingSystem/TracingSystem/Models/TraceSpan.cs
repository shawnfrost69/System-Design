using System.Runtime.InteropServices.JavaScript;

namespace TracingSystem.Models;

public class TraceSpan
{
    public string TraceId { get; set; }
    public string SpanId { get; set; }
    public string? ParentSpanId { get; set; }
    public string OperationName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public Dictionary<string, string> Tags { get; set; } = new();
}