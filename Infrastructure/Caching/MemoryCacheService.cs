using Asp_net_Core_API_Assignment_1.Application.Interfaces;
using static Asp_net_Core_API_Assignment_1.Infrastructure.Caching.Configuration;
using Microsoft.Extensions.Caching.Memory;
namespace Asp_net_Core_API_Assignment_1.Infrastructure.Caching
{
    public class MemoryCacheService(IMemoryCache cache) : ICacheService
    {
        private readonly IMemoryCache _cache = cache;

        public List<Domain.Entities.Task> GetTasks()
        {
            if (!_cache.TryGetValue(CACHE_KEY, out List<Domain.Entities.Task>? tasks))
            {
                tasks = [];
                for (int i = 0; i < MOCK_QUANTITY; i++)
                {
                    tasks.Add(Domain.Entities.Task.CreateRandomTask());
                }
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(EXPIRE_TIME));

                _cache.Set(CACHE_KEY, tasks, cacheOptions);
            }
            return tasks ?? [];
        }
        public void SetTasks(List<Domain.Entities.Task> tasks)
        {
            _cache.Set(CACHE_KEY, tasks);
        }
    }
}
