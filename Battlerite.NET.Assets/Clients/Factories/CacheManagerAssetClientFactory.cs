using System.Collections.ObjectModel;
using System.Net.Http;
using Battlerite.NET.Assets.Stackables;
using CacheManager.Core;

namespace Battlerite.NET.Assets.Clients.Factories
{
    public class CacheManagerAssetClientFactory : IAssetClientFactory
    {
        private readonly ICacheManagerConfiguration cacheManagerConfiguration;

        public CacheManagerAssetClientFactory(ICacheManagerConfiguration cacheManagerConfiguration)
        {
            this.cacheManagerConfiguration = cacheManagerConfiguration;
        }

        public IAssetClient Create(HttpClient httpClient)
        {
            return new CachedAssetClient(
                httpClient,
                new BaseCacheManager<ReadOnlyDictionary<long, Mapping>>(cacheManagerConfiguration));
        }
    }
}