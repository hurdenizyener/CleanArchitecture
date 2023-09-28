namespace Application.Common.Pipelines.Caching;

public interface ICachableRequest
{
    string CacheKey { get; }
    bool Bypass { get; }
    string? CacheGroupKey { get; }
    TimeSpan? SlidingExpiration { get; } //Cache Ne Kadar Süre Duracak

}
