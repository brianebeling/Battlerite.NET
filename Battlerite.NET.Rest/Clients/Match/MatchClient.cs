using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Battlerite.NET.Rest.Clients.Match.Builder;
using Battlerite.NET.Rest.Parameters;
using Battlerite.NET.Rest.Requester;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.Clients.Match
{
    public class MatchClient : IMatchClient
    {
        private readonly IRequestUrlBuilder builder;
        private readonly JsonSerializerSettings jsonSerializerSettings;
        private readonly IRequester requester;

        internal MatchClient(
            IRequestUrlBuilder builder,
            IRequester requester,
            JsonSerializerSettings jsonSerializerSettings)
        {
            this.builder = builder;
            this.requester = requester;
            this.jsonSerializerSettings = jsonSerializerSettings;
        }

        public async Task<DTOs.Matches.Match> GetMatchAsync(string id)
        {
            var request
                = await requester.Request<DTOs.Matches.Match>(
                    builder.Build(
                        EndPoints.SingleMatch + id,
                        new List<IParameter>()),
                    jsonSerializerSettings);

            return request;
        }

        public async Task<IEnumerable<DTOs.Matches.Match>> GetMatchCollectionAsync(
            Action<MatchCollectionParameterBuilder> parameterBuilder)
        {
            var tempParameterBuilder = new MatchCollectionParameterBuilder();
            parameterBuilder.Invoke(tempParameterBuilder);

            var request = await requester.Request<IEnumerable<DTOs.Matches.Match>>(
                builder.Build(EndPoints.Matches, tempParameterBuilder.Build()),
                jsonSerializerSettings);

            return request;
        }
    }
}