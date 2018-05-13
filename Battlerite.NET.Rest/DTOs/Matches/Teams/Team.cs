using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches.Teams
{
    public class Team
    {
        [JsonProperty("assets")]
        public IEnumerable<Asset> Assets { get; private set; }

        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("shardId")]
        public string ShardId { get; private set; }

        // TODO NOT IMPLEMENTED: Attributes

        // TODO NOT IMPLEMENTED
        [Obsolete("This member hasn't been implemented by Stunlock Studios yet")]
        public Stats Stats { get; private set; }
    }
}