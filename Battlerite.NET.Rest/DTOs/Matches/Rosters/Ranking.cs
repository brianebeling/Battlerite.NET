using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches.Rosters
{
    public class Ranking
    {
        [JsonProperty("disvision")]
        public int Division { get; private set; }

        [JsonProperty("league")]
        public int League { get; private set; }

        [JsonProperty("divisionRating")]
        public int Rating { get; private set; }
    }
}