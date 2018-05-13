using Battlerite.NET.Assets.Clients;
using Battlerite.NET.Rest.Requester;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.Clients.Player
{
    public class PlayerClientFactory : IPlayerClientFactory
    {
        public PlayerClient Create(
            IAssetClient assetClient,
            IRequestUrlBuilder requestUrlBuilder,
            IRequester requester,
            JsonSerializerSettings jsonApiSerializerSettings)
        {
            return new PlayerClient(assetClient, requestUrlBuilder, requester, jsonApiSerializerSettings);
        }
    }
}