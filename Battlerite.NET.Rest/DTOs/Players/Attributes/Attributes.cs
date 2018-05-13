using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Players.Attributes
{
    /// <summary>
    ///     The attributes of the player. NOT IMPLEMENTED: Seems to be always empty.
    /// </summary>
    public class Attributes
    {
        [JsonProperty("name")]
        public string Name { get; protected set; }

        [JsonProperty("patchVersion")]
        public string PatchVersion { get; protected set; }

        [JsonProperty("shardId")]
        public string ShardId { get; protected set; }
    }
}