using Battlerite.NET.Rest.Requester;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.Clients.Match
{
    public class MatchClientFactory : IMatchClientFactory
    {
        public MatchClient Create(
            IRequestUrlBuilder requestUrlBuilder,
            IRequester requester,
            JsonSerializerSettings jsonSerializerSettings)
        {
            return new MatchClient(requestUrlBuilder, requester, jsonSerializerSettings);
        }
    }
}