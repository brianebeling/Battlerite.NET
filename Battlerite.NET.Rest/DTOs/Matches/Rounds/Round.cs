using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches.Rounds
{
    public class Round
    {
        [JsonProperty("duration")]
        public int Duration { get; private set; }

        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("ordinal")]
        public int Ordinal { get; private set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }
    }
}