using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection.Data.Relationships
{
    public class Relationships
    {
        [JsonProperty("assets")]
        public Relation Assets { get; set; }

        [JsonProperty("rosters")]
        public Relation Rosters { get; set; }

        [JsonProperty("rounds")]
        public Relation Rounds { get; set; }

        [JsonProperty("spectators")]
        public Relation Spectators { get; set; }
    }
}