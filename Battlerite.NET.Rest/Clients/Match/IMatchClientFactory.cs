using Battlerite.NET.Rest.Requester;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.Clients.Match
{
    public interface IMatchClientFactory
    {
        MatchClient Create(
            IRequestUrlBuilder requestUrlBuilder,
            IRequester requester,
            JsonSerializerSettings jsonSerializerSettings);
    }
}