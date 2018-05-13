using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches
{
    public class Stats
    {
        [JsonProperty("mapID")]
        public string MapId { get; set; }
    }
}