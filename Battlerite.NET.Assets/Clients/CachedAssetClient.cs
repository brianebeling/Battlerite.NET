using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Battlerite.NET.Assets.Stackables;
using CacheManager.Core;

namespace Battlerite.NET.Assets.Clients
{
    public class CachedAssetClient : AssetClientBase
    {
        private readonly ICacheManager<ReadOnlyDictionary<long, Mapping>> stackablesCacheManager;

        internal CachedAssetClient(
            HttpClient httpClient,
            ICacheManager<ReadOnlyDictionary<long, Mapping>> stackablesCacheManager) : base(httpClient)
        {
            this.stackablesCacheManager = stackablesCacheManager;
        }

        public override async Task<IReadOnlyDictionary<long, Mapping>> GetStackablesAsync(string revision)
        {
            return await stackablesCacheManager.GetOrAddAsync(revision, DownloadStackablesAsync);
        }

        public override async Task<IReadOnlyDictionary<long, Mapping>> GetStackablesAsync()
        {
            // TODO Maybe replace with algorithm to find latest revision
            return await stackablesCacheManager.GetOrAddAsync("45166", DownloadStackablesAsync);
        }
    }
}