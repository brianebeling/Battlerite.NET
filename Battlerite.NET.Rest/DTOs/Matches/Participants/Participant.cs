using Battlerite.NET.Rest.Converters;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches.Participants
{
    public class Participant
    {
        [JsonProperty("actor")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int Actor { get; private set; }

        [JsonProperty("id")]
        public string Id { get; private set; }

        //[JsonProperty("player")]
        //public Player Player { get; private set; }

        [JsonProperty("shardId")]
        public string ShardId { get; private set; }

        [JsonProperty("stats")]
        public Stats Stats { get; private set; }
    }
}