using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Players.Attributes
{
    /// <inheritdoc />
    /// <summary>
    ///     The attributes of the player.
    /// </summary>
    public class PopulatedAttributes : Attributes
    {
        [JsonProperty("stats")]
        public Stats.Stats Stats { get; private set; }

        public PopulatedAttributes(string name, string patchVersion, string shardId, Stats.Stats stats)
        {
            Name = name;
            PatchVersion = patchVersion;
            ShardId = shardId;
            Stats = stats;
        }
    }
}