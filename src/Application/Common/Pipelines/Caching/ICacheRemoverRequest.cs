namespace Application.Common.Pipelines.Caching;

public interface ICacheRemoverRequest
{
    string? CacheKey { get; }
    bool Bypass { get; }
    string? CacheGroupKey { get; }
}
