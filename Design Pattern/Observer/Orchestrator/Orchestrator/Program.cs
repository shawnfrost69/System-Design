using Orchestrator.Models;
using Orchestrator.Services;
namespace Orchestrator;


class Program
{
    static void Main(string[] args)
    {
        var orch = new Services.Orchestrator();
        
        orch.AddProcess(new Process("EmailJob", 1));
        orch.AddProcess(new Process("BackUpJob", 5));
        orch.AddProcess(new Process("ReportJob", 3));
        
        Console.WriteLine("Next: " + orch.GetNextProcess()?.Id);
        Console.WriteLine("Next: " + orch.GetNextProcess()?.Id);

        while (!orch.IsEmpty())
        {
            var next = orch.GetNextProcess();
            Console.WriteLine($"Processing: {next.Id}, Priority: {next.Priority}");
        }
    }
}