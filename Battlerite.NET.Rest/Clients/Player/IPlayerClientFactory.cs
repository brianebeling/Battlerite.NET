using Battlerite.NET.Assets.Clients;
using Battlerite.NET.Rest.Requester;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.Clients.Player
{
    public interface IPlayerClientFactory
    {
        PlayerClient Create(
            IAssetClient assetClient,
            IRequestUrlBuilder requestUrlBuilder,
            IRequester requester,
            JsonSerializerSettings jsonApiSerializerSettings);
    }
}