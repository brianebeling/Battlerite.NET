using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches.Rosters
{
    public class PreviousRanking
    {
        [JsonProperty("prevDisvision")]
        public int Division { get; private set; }

        [JsonProperty("prevLeague")]
        public int League { get; private set; }

        [JsonProperty("prevDivisionRating")]
        public int Rating { get; private set; }
    }
}