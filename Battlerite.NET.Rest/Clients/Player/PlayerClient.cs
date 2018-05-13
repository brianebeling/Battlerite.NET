using System.Collections.Generic;
using System.Threading.Tasks;
using Battlerite.NET.Assets.Clients;
using Battlerite.NET.Assets.Stackables;
using Battlerite.NET.Rest.Converters;
using Battlerite.NET.Rest.DTOs.Players;
using Battlerite.NET.Rest.Parameters;
using Battlerite.NET.Rest.Requester;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.Clients.Player
{
    public class PlayerClient
        : IPlayerClient
    {
        private readonly IRequestUrlBuilder builder;
        private readonly IAssetClient cachedAssetClient;
        private readonly JsonSerializerSettings jsonApiSerializerSettings;
        private readonly IRequester requester;

        private IReadOnlyDictionary<long, Mapping> stackables;

        internal PlayerClient(
            IAssetClient cachedAssetClient,
            IRequestUrlBuilder builder,
            IRequester requester,
            JsonSerializerSettings jsonApiSerializerSettings)
        {
            this.cachedAssetClient = cachedAssetClient;
            this.requester = requester;
            this.jsonApiSerializerSettings = jsonApiSerializerSettings;
            this.builder = builder;
        }

        public async Task<PopulatedPlayer> GetPlayerByPlayerIdAsync(long id)
        {
            await UpdateStackables();

            return await requester.Request<PopulatedPlayer>(
                builder.Build(EndPoints.SinglePlayer + id),
                jsonApiSerializerSettings);
        }

        public async Task<IReadOnlyList<PopulatedPlayer>> GetPlayersByNameAsync(IEnumerable<string> playerNames)
        {
            return await GetPlayersByFilter(PlayerFilter.PlayerName, playerNames);
        }

        public async Task<IReadOnlyList<PopulatedPlayer>> GetPlayersByPlayerIdAsync(IEnumerable<long> playerIds)
        {
            return await GetPlayersByFilter(PlayerFilter.PlayerId, playerIds);
        }

        public async Task<IReadOnlyList<PopulatedPlayer>> GetPlayersBySteamIdAsync(IEnumerable<ulong> steamIds)
        {
            return await GetPlayersByFilter(PlayerFilter.SteamId, steamIds);
        }

        private async Task<IReadOnlyList<PopulatedPlayer>> GetPlayersByFilter<T>(
            string filterName,
            IEnumerable<T> filter)
        {
            await UpdateStackables();

            return await requester.Request<IReadOnlyList<PopulatedPlayer>>(
                builder.Build(
                    EndPoints.Players,
                    new List<IParameter>
                    {
                        new Parameter($"filter[{filterName}]", string.Join(",", filter))
                    }),
                jsonApiSerializerSettings);
        }

        private async Task UpdateStackables()
        {
            var newStackables = await cachedAssetClient.GetStackablesAsync();

            if (stackables == null || stackables != newStackables)
            {
                stackables = newStackables;
                jsonApiSerializerSettings.Converters.Add(new PopulatedAttributesJsonConverter(stackables));
            }
        }
    }
}