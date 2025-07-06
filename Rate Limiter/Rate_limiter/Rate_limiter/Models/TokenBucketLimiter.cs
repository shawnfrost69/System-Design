using Rate_limiter.Interfaces;

namespace Rate_limiter.Models;

public class TokenBucketLimiter : IRateLimiter
{
    private readonly int _capacity;
    private double _tokens;
    private readonly double _refillRatePerSec;
    private long _lastRefillTimestamp;
    private readonly object _lock = new();

    public TokenBucketLimiter(int capacity, double refillRatePerSec)
    {
        _capacity = capacity;
        _tokens = capacity;
        _refillRatePerSec = refillRatePerSec;
        _lastRefillTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    public bool IsAllowed()
    {
        lock (_lock)
        {
            Refill();

            if (_tokens >= 1)
            {
                _tokens--;
                return true;
            }

            return false;
        }
    }

    private void Refill()
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        double secondPassed = (now - _lastRefillTimestamp) / 1000.0;

        double tokensToAdd = secondPassed * _refillRatePerSec;

        if (tokensToAdd > 0)
        {
            _tokens = Math.Min(_capacity, _tokens + tokensToAdd);
            _lastRefillTimestamp = now;
        }
    }
}