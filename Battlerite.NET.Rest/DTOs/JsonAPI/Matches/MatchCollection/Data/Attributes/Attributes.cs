using System;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection.Data.Attributes
{
    public class Attributes
    {
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("patchVersion")]
        public string PatchVersion { get; set; }

        [JsonProperty("shardId")]
        public string ShardId { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("tags")]
        public Tags Tags { get; set; }

        [JsonProperty("titleId")]
        public string TitleId { get; set; }
    }
}