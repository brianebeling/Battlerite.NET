using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Battlerite.NET.Assets.Stackables;
using Newtonsoft.Json;

namespace Battlerite.NET.Assets.Clients
{
    public abstract class AssetClientBase : IAssetClient
    {
        protected readonly HttpClient HttpClient;

        protected AssetClientBase(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public abstract Task<IReadOnlyDictionary<long, Mapping>> GetStackablesAsync(string revision);
        public abstract Task<IReadOnlyDictionary<long, Mapping>> GetStackablesAsync();

        protected static string GetStackablesPageUrl(string revision)
        {
            return
                $"https://raw.githubusercontent.com/StunlockStudios/battlerite-assets/master/mappings/{revision}/stackables.json";
        }

        // TODO https://github.com/StunlockStudios/battlerite-assets/tree/master/mappings/39187/localization
        //public async Task<Localization> GetLocalization()
        //{
        //    return null;
        //}

        protected async Task<ReadOnlyDictionary<long, Mapping>> DownloadStackablesAsync(string revision)
        {
            var stackablesPageUrl = GetStackablesPageUrl(revision);

            var response = await HttpClient.GetAsync(stackablesPageUrl);
            var content = response.Content;
            var result = await content.ReadAsStringAsync();

            // TODO: Write Json Converter that skips the deserilization to Stackables
            var deserializedStackables = JsonConvert.DeserializeObject<Stackables.Stackables>(result);

            return new ReadOnlyDictionary<long, Mapping>(
                deserializedStackables.Mappings
                    .OrderBy(x => x.StackableId)
                    .ToDictionary(
                        mappingKey => mappingKey.StackableId,
                        mappingValue => mappingValue));
        }
    }
}