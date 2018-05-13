using System;
using System.Collections.Generic;
using Battlerite.NET.Rest.DTOs.Matches.Rosters;
using Battlerite.NET.Rest.DTOs.Matches.Rounds;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches
{
    public class Match
    {
        [JsonProperty("assets")]
        public IEnumerable<Asset> Assets { get; private set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("patchVersion")]
        public string PatchVersion { get; set; }

        [JsonProperty("rosters")]
        public IEnumerable<Roster> Rosters { get; private set; }

        [JsonProperty("rounds")]
        public IEnumerable<Round> Rounds { get; private set; }

        [JsonProperty("shardId")]
        public string ShardId { get; set; }

        // TODO NOT IMPLEMENTED
        //[JsonProperty("spectators")]
        [Obsolete("This Member hasn't been implemented by Stunlock Studios yet")]
        public IEnumerable<Spectator> Spectators { get; private set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("tags")]
        public Tags Tags { get; set; }
    }
}