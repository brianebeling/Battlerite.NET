using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches.Rosters
{
    public class RosterMetrics
    {
        [JsonProperty("losses")]
        public int Lost { get; private set; }

        [JsonProperty("wins")]
        public int Won { get; private set; }
    }
}