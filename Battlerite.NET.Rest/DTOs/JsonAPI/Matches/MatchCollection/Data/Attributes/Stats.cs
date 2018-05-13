using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection.Data.Attributes
{
    public class Stats
    {
        [JsonProperty("mapID")]
        public string MapId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}