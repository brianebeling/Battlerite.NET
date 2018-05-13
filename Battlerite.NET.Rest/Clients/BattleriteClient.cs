using Battlerite.NET.Assets.Clients;
using Battlerite.NET.Rest.Clients.Match;
using Battlerite.NET.Rest.Clients.Player;

namespace Battlerite.NET.Rest.Clients
{
    public class BattleriteClient

    {
        public IAssetClient Assets { get; }
        public IMatchClient Matches { get; }

        public IPlayerClient Players { get; }

        internal BattleriteClient(
            IAssetClient assets,
            IMatchClient matches,
            IPlayerClient players)
        {
            Players = players;
            Matches = matches;
            Assets = assets;
        }

        // TODO Get Map by Id
        // TODO Get Team
        // TODO Get Status
        // TODO Get Latency
        // TODO Telemetry Project
    }
}