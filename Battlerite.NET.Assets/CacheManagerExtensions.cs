using System;
using System.Threading.Tasks;
using CacheManager.Core;

namespace Battlerite.NET.Assets
{
    internal static class CacheManagerExtensions
    {
        public static async Task<T> GetOrAddAsync<T>(
            this ICacheManager<T> cacheManager,
            string key,
            Func<string, Task<T>> valueFactory,
            ExpirationMode expirationMode,
            TimeSpan timeout)
        {
            T result;

            if (cacheManager.Exists(key))
            {
                result = cacheManager.Get<T>(key);
            }
            else
            {
                result = await valueFactory(key).ConfigureAwait(false);
                cacheManager.Add(new CacheItem<T>(key, result, expirationMode, timeout));
            }

            return result;
        }

        public static async Task<T> GetOrAddAsync<T>(
            this ICacheManager<T> cacheManager,
            string key,
            Func<string, Task<T>> valueFactory)
        {
            T result;

            if (cacheManager.Exists(key))
            {
                result = cacheManager.Get<T>(key);
            }
            else
            {
                result = await valueFactory(key).ConfigureAwait(false);
                cacheManager.Add(new CacheItem<T>(key, result));
            }

            return result;
        }
    }
}