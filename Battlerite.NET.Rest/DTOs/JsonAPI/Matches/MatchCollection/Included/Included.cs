using Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection.Included.Attribute;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection.Included
{
    public class Included
    {
        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        public MatchCollection.Data.Links.Links Links { get; set; }

        [JsonProperty("relationships", NullValueHandling = NullValueHandling.Ignore)]
        public Relationships Relationships { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }
    }
}