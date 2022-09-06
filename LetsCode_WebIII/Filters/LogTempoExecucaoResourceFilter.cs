using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace LetsCode_WebIII.Filters
{
    public class LogTempoExecucaoResourceFilter : IResourceFilter
    {
        Stopwatch stopwatch = new();
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            stopwatch.Stop();
            Console.WriteLine($"\nTempo do processo: {stopwatch.ElapsedMilliseconds} ms");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            stopwatch.Start();
        }
    }
}
