using Rate_limiter.Interfaces;
using Rate_limiter.Models;

namespace Rate_limiter.Manager;

public class RateLimiterManager
{
    private readonly Dictionary<string, IRateLimiter> _limiters = new();
    
    public IRateLimiter GetRateLimiter(string userId)
    {
        if (!_limiters.ContainsKey(userId))
        {
            _limiters[userId] = new TokenBucketLimiter(5, 1);
        }
        
        return _limiters[userId];
    }
}