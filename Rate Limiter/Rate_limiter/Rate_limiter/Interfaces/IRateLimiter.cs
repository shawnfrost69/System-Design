namespace Rate_limiter.Interfaces;

public interface IRateLimiter
{
    bool IsAllowed();
}