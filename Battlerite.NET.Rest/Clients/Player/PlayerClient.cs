using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battlerite.NET.Assets.Clients;
using Battlerite.NET.Assets.Stackables;
using Battlerite.NET.Rest.Converters;
using Battlerite.NET.Rest.DTOs.Players;
using Battlerite.NET.Rest.Parameters;
using Battlerite.NET.Rest.Requester;
using Newtonsoft.Json;
using Optional;

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

        public async Task<Option<PopulatedPlayer>> GetPlayerByNameAsync(string playerName)
        {
            return Option.Some(await GetPlayerByFilter(PlayerFilter.PlayerName, playerName));
        }

        public async Task<Option<PopulatedPlayer>> GetPlayerByPlayerIdAsync(long id)
        {
            await UpdateStackables();

            return Option.Some(
                await requester.Request<PopulatedPlayer>(
                    builder.Build(EndPoints.SinglePlayer + id),
                    jsonApiSerializerSettings));
        }

        public async Task<Option<PopulatedPlayer>> GetPlayerBySteamIdAsync(ulong steamId)
        {
            return Option.Some(await GetPlayerByFilter(PlayerFilter.SteamId, steamId.ToString()));
        }

        public async Task<Option<IReadOnlyList<PopulatedPlayer>>> GetPlayersByNameAsync(IEnumerable<string> playerNames)
        {
            return await GetPlayersByFilter(PlayerFilter.PlayerName, playerNames);
        }

        public async Task<Option<IReadOnlyList<PopulatedPlayer>>> GetPlayersByPlayerIdAsync(IEnumerable<long> playerIds)
        {
            return await GetPlayersByFilter(PlayerFilter.PlayerId, playerIds);
        }

        public async Task<Option<IReadOnlyList<PopulatedPlayer>>> GetPlayersBySteamIdAsync(IEnumerable<ulong> steamIds)
        {
            return await GetPlayersByFilter(PlayerFilter.SteamId, steamIds);
        }

        private async Task<PopulatedPlayer> GetPlayerByFilter(
            string filterName,
            string filterItem)
        {
            await UpdateStackables();

            var result = await requester.Request<IReadOnlyList<PopulatedPlayer>>(
                builder.Build(
                    EndPoints.Players,
                    new List<IParameter>
                    {
                        new Parameter($"filter[{filterName}]", filterItem)
                    }),
                jsonApiSerializerSettings);

            return result.FirstOrDefault();
        }

        private async Task<Option<IReadOnlyList<PopulatedPlayer>>> GetPlayersByFilter<T>(
            string filterName,
            IEnumerable<T> filterItems)
        {
            await UpdateStackables();

            return Option.Some(
                await requester.Request<IReadOnlyList<PopulatedPlayer>>(
                    builder.Build(
                        EndPoints.Players,
                        new List<IParameter>
                        {
                            new Parameter($"filter[{filterName}]", string.Join(",", filterItems))
                        }),
                    jsonApiSerializerSettings));
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