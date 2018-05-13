using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Battlerite.NET.Assets.Clients;
using Battlerite.NET.Assets.Clients.Factories;
using Battlerite.NET.Rest.Clients.Match;
using Battlerite.NET.Rest.Clients.Player;
using Battlerite.NET.Rest.Parameters;
using Battlerite.NET.Rest.RateLimit;
using Battlerite.NET.Rest.Requester;
using JsonApiSerializer;

namespace Battlerite.NET.Rest.Clients
{
    public class BattleriteClientFactory
    {
        public BattleriteClient Create(
            string token,
            IRateLimitPolicy rateLimitPolicy = default)
        {

            if (rateLimitPolicy == default(IRateLimitPolicy))
                rateLimitPolicy = new RateLimitPolicy();

            var jsonSerializerSettings = new JsonApiSerializerSettings();

            var requestUrlBuilder = new RequestUrlBuilder(EndPoints.BaseUrl, new List<IParameter>());

            var httpClient = new HttpClient();

            var requester = new Requester.Requester(httpClient, rateLimitPolicy);

            var cachedAssetClientFactory = new CachedAssetClientFactory();
            var cachedAssetClient = cachedAssetClientFactory.Create(new HttpClient());

            var playerClientFactory = new PlayerClientFactory();
            var playerClient = playerClientFactory.Create(
                cachedAssetClient,
                requestUrlBuilder,
                requester,
                jsonSerializerSettings);

            var matchClientFactory = new MatchClientFactory();
            var matchClient = matchClientFactory.Create(
                requestUrlBuilder,
                requester,
                new JsonApiSerializerSettings());

            var client
                = new BattleriteClient(
                    cachedAssetClient,
                    matchClient,
                    playerClient);

            httpClient.BaseAddress = new Uri(EndPoints.BaseUrl);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));

            return client;
        }

        public BattleriteClient Create(
            IAssetClient assetClient,
            IMatchClient matchClient,
            IPlayerClient playerClient)
        {
            return new BattleriteClient(assetClient, matchClient, playerClient);
        }
    }
}