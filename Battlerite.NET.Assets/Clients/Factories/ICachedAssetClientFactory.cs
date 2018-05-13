using System.Net.Http;
using CacheManager.Core;

namespace Battlerite.NET.Assets.Clients.Factories
{
    public interface ICachedAssetClientFactory : IAssetClientFactory
    {
        IAssetClient Create(HttpClient httpClient, CacheManagerConfiguration cacheManagerConfiguration);
    }
}