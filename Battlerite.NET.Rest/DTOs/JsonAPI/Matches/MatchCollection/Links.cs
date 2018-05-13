using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection
{
    public class Links
    {
        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }
    }
}