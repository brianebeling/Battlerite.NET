using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Battlerite.NET.Assets.Stackables;

namespace Battlerite.NET.Assets.Clients
{
    public class AssetClient : AssetClientBase
    {
        public AssetClient(HttpClient httpClient) : base(httpClient)
        {
        }

        // TODO https://github.com/StunlockStudios/battlerite-assets/tree/master/mappings/39187/localization
        //public async Task<Localization> GetLocalization()
        //{
        //    return null;
        //}

        public override async Task<IReadOnlyDictionary<long, Mapping>> GetStackablesAsync(string revision)
        {
            return await DownloadStackablesAsync(revision);
        }

        public override async Task<IReadOnlyDictionary<long, Mapping>> GetStackablesAsync()
        {
            // TODO Maybe replace with algorithm to find latest revision
            return await DownloadStackablesAsync("45166");
        }
    }
}