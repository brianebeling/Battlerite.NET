using Battlerite.NET.Rest.DTOs.Players.Attributes;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Players
{
    public class PopulatedPlayer
    {
        [JsonProperty("attributes")]
        public PopulatedAttributes Attributes { get; private set; }

        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("links")]
        public Links Links { get; private set; }
    }
}