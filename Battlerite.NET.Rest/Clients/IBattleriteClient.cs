using Battlerite.NET.Assets.Clients;
using Battlerite.NET.Rest.Clients.Match;
using Battlerite.NET.Rest.Clients.Player;

namespace Battlerite.NET.Rest.Clients
{
    public interface IBattleriteClient
    {
        IAssetClient Assets { get; }
        IMatchClient Matches { get; }
        IPlayerClient Players { get; }
    }
}