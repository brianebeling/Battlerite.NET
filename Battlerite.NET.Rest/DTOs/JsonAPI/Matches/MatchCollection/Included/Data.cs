using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection.Included
{
    public class Data
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }
    }
}