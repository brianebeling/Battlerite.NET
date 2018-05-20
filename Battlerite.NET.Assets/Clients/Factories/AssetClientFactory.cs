using System.Collections.ObjectModel;
using System.Net.Http;
using Battlerite.NET.Assets.Stackables;
using CacheManager.Core;

namespace Battlerite.NET.Assets.Clients.Factories
{
    public class AssetClientFactory : IAssetClientFactory
    {
        public IAssetClient Create(
            HttpClient httpClient)
        {
            return new AssetClient(httpClient);
        }
    }
}