using System.Collections.Generic;
using Battlerite.NET.Rest.Converters;
using Battlerite.NET.Rest.DTOs.Matches.Participants;
using Battlerite.NET.Rest.DTOs.Matches.Teams;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches.Rosters
{
    public class Roster
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("participants")]
        public IEnumerable<Participant> Participants { get; private set; }

        [JsonProperty("shardId")]
        public string ShardId { get; private set; }

        [JsonProperty("stats")]
        [JsonConverter(typeof(StatsJsonConverter))]
        public Stats Stats { get; private set; }

        [JsonProperty("team")]
        public Team Team { get; private set; }

        [JsonProperty("won")]
        public bool Won { get; private set; }
    }
}