using System;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches
{
    public class Asset
    {
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("URL")]
        public string Url { get; private set; }
    }
}