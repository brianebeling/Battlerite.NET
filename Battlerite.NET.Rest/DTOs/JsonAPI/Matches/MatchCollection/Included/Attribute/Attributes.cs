using System;
using Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection.Data.Links;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.JsonAPI.Matches.MatchCollection.Included.Attribute
{
    public class Attributes
    {
        [JsonProperty("actor", NullValueHandling = NullValueHandling.Ignore)]
        public string Actor { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public long? Duration { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public Name? Name { get; set; }

        [JsonProperty("ordinal", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ordinal { get; set; }

        [JsonProperty("patchVersion", NullValueHandling = NullValueHandling.Ignore)]
        public Schema? PatchVersion { get; set; }

        [JsonProperty("shardId", NullValueHandling = NullValueHandling.Ignore)]
        public ShardId? ShardId { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("titleId", NullValueHandling = NullValueHandling.Ignore)]
        public TitleId? TitleId { get; set; }

        [JsonProperty("URL", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("won", NullValueHandling = NullValueHandling.Ignore)]
        public string Won { get; set; }
    }
}