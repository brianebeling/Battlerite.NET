using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection.Included
{
    public class Relationships
    {
        [JsonProperty("assets", NullValueHandling = NullValueHandling.Ignore)]
        public MatchCollection.Data.Relationships.Assets Assets { get; set; }

        [JsonProperty("participants", NullValueHandling = NullValueHandling.Ignore)]
        public Participants Participants { get; set; }

        [JsonProperty("player", NullValueHandling = NullValueHandling.Ignore)]
        public Player Player { get; set; }

        [JsonProperty("team", NullValueHandling = NullValueHandling.Ignore)]
        public Team Team { get; set; }
    }
}