using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches.Rounds
{
    public class Stats
    {
        [JsonProperty("winningTeam")]
        public int WinningTeam { get; private set; }
    }
}