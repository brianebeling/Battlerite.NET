using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches.Rosters
{
    public class RoundMetrics
    {
        [JsonProperty("roundsLost")]
        public int Lost { get; private set; }

        [JsonProperty("roundsWon")]
        public int Won { get; private set; }
    }
}