using System.Net.Http;

namespace Battlerite.NET.Assets.Clients.Factories
{
    public interface IAssetClientFactory
    {
        IAssetClient Create(HttpClient httpClient);
    }
}