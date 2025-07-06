using Orchestrator.Models;

namespace Orchestrator.Services;

public class Orchestrator
{
    private readonly object _lock = new();
    private readonly PriorityQueue<Process, (int, DateTime)> _queue;

    public Orchestrator()
    {
        _queue = new PriorityQueue<Process, (int, DateTime)>(Comparer<(int, DateTime)>.Create(
            (a, b) =>
            {
                int cmp = b.Item1.CompareTo(a.Item1);
                return cmp == 0 ? a.Item2.CompareTo(b.Item2) : cmp;
            }));
    }

    public void AddProcess(Process process)
    {
        lock (_lock)
        {
            _queue.Enqueue(process, (process.Priority, process.TimeStamp));
        }
    }

    public Process? GetNextProcess()
    {
        lock (_lock)
        {
            return _queue.Count > 0 ?_queue.Dequeue() : null;
        }
    }

    public void UpdatePriority(string id, int newPriority)
    {
        lock (_lock)
        {
            var temp = new List<Process>();

            while (_queue.Count > 0)
            {
                var p = _queue.Dequeue();
                if (p.Id == id)
                {
                    p.Priority = newPriority;
                }
                temp.Add(p);
            }

            foreach (var p in temp)
            {
                _queue.Enqueue(p, (p.Priority, p.TimeStamp));
            }
        }
    }
    public bool IsEmpty()
    {
        lock (_lock)
        {
            return _queue.Count == 0;
        }
    }
}