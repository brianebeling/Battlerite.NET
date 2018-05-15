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
using Newtonsoft.Json;
using Optional;

namespace Battlerite.NET.Rest.Clients
{
    public class BattleriteClientBuilder
    {
        private Option<IAssetClientFactory> assetClientFactory;
        private Option<IMatchClientFactory> matchClientFactory;
        private Option<IPlayerClientFactory> playerClientFactory;

        private RateLimitPolicy rateLimitPolicy;

        public BattleriteClient Build(string token)
        {
            if (rateLimitPolicy == default(IRateLimitPolicy))
                rateLimitPolicy = new RateLimitPolicy();

            var jsonSerializerSettings = new JsonApiSerializerSettings();

            var requestUrlBuilder = new RequestUrlBuilder(EndPoints.BaseUrl, new List<IParameter>());

            var httpClient = new HttpClient();
            SetupHttpClient(token, httpClient);

            var requester = new Requester.Requester(httpClient, rateLimitPolicy);

            return CreateBattleriteClient(
                CreateOrGetAssetClient(),
                CreateOrGetPlayerClient(
                    jsonSerializerSettings,
                    requestUrlBuilder,
                    requester,
                    CreateOrGetAssetClient()),
                CreateOrGetMatchClient(requestUrlBuilder, requester));
        }

        public BattleriteClientBuilder WithAssetClientFactory(IAssetClientFactory assetClientFactory)
        {
            this.assetClientFactory = Option.Some(assetClientFactory);
            return this;
        }

        public BattleriteClientBuilder WithMatchClientFactory(IMatchClientFactory matchClientFactory)
        {
            this.matchClientFactory = Option.Some(matchClientFactory);
            return this;
        }

        public BattleriteClientBuilder WithPlayerClientFactory(IPlayerClientFactory playerClientFactory)
        {
            this.playerClientFactory = Option.Some(playerClientFactory);
            return this;
        }

        public BattleriteClientBuilder WithRateLimitPolicy(RateLimitPolicy rateLimitPolicy)
        {
            this.rateLimitPolicy = rateLimitPolicy;
            return this;
        }

        private static BattleriteClient CreateBattleriteClient(
            IAssetClient assetClient,
            IPlayerClient playerClient,
            IMatchClient matchClient)
        {
            return new BattleriteClient(
                assetClient,
                matchClient,
                playerClient);
        }

        private static void SetupHttpClient(string token, HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(EndPoints.BaseUrl);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
        }

        private IAssetClient CreateOrGetAssetClient()
        {
            IAssetClient assetClient = null;

            assetClientFactory.Or(() => new AssetClientFactory())
                .MatchSome(factory => assetClient = factory.Create(new HttpClient()));

            return assetClient;
        }

        private IMatchClient CreateOrGetMatchClient(IRequestUrlBuilder requestUrlBuilder, IRequester requester)
        {
            IMatchClient matchClient = null;

            matchClientFactory.Or(() => new MatchClientFactory())
                .MatchSome(
                    factory => matchClient = factory.Create(
                        requestUrlBuilder,
                        requester,
                        new JsonApiSerializerSettings()));

            return matchClient;
        }

        private IPlayerClient CreateOrGetPlayerClient(
            JsonSerializerSettings jsonSerializerSettings,
            IRequestUrlBuilder requestUrlBuilder,
            IRequester requester,
            IAssetClient assetClient)
        {
            IPlayerClient playerClient = null;

            playerClientFactory.Or(() => new PlayerClientFactory())
                .MatchSome(
                    factory => playerClient = factory.Create(
                        assetClient,
                        requestUrlBuilder,
                        requester,
                        jsonSerializerSettings));

            return playerClient;
        }
    }
}