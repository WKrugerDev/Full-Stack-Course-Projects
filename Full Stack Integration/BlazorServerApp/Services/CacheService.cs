using Microsoft.Extensions.Caching.Memory;

namespace BlazorServerApp.Services
{
    public class CacheService
    {
        private readonly IMemoryCache _cache;
        
        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        } 
        public T GetOrCreate<T>(string key, Func<ICacheEntry, T> createItem)
        {
            return _cache.GetOrCreate(key, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                return createItem(entry);
            });
        }
    } 
}