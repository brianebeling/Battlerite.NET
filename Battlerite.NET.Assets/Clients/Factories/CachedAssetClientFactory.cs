using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Battlerite.NET.Assets.Stackables;
using CacheManager.Core;

namespace Battlerite.NET.Assets.Clients.Factories
{
    public class CachedAssetClientFactory : ICachedAssetClientFactory
    {
        public IAssetClient Create(HttpClient httpClient)
        {
            void Settings(ConfigurationBuilderCachePart configurationBuilder)
            {
                var handlerBuilder = configurationBuilder.WithDictionaryHandle();
                handlerBuilder.WithExpiration(ExpirationMode.Absolute, TimeSpan.FromMinutes(1));
            }

            return new CachedAssetClient(
                httpClient,
                CacheFactory.Build<ReadOnlyDictionary<long, Mapping>>(Settings));
        }

        public IAssetClient Create(HttpClient httpClient, CacheManagerConfiguration cacheManagerConfiguration)
        {
            return new CachedAssetClient(
                httpClient,
                new BaseCacheManager<ReadOnlyDictionary<long, Mapping>>(cacheManagerConfiguration));
        }
    }
}