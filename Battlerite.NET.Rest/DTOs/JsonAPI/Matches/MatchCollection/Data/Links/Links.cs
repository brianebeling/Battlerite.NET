using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection.Data.Links
{
    public class Links
    {
        [JsonProperty("schema")]
        public Schema Schema { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }
    }
}