using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection.Data
{
    public class Data
    {
        [JsonProperty("attributes")]
        public Attributes.Attributes Attributes { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("links")]
        public Links.Links Links { get; set; }

        [JsonProperty("relationships")]
        public Relationships.Relationships Relationships { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}