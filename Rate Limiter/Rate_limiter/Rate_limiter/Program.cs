using Rate_limiter.Manager;

namespace Rate_limiter;

class Program
{
    static void Main(string[] args)
    {
        var rateLimiterManager = new RateLimiterManager();

        for (int i = 0; i < 25; i++)
        {
            var limiter = rateLimiterManager.GetRateLimiter("user123");
            Console.WriteLine($"Request{i + 1}: {(limiter.IsAllowed() ? "Allowed" : "Blocked")}");
            Thread.Sleep(300);
        }
    }
}
