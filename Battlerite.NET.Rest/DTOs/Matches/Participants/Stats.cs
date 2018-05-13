using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches.Participants
{
    public class Stats
    {
        [JsonProperty("abilityUses")]
        public long AbilityUses { get; private set; }

        [JsonProperty("attachment")]
        public long Attachment { get; private set; }

        [JsonProperty("damageDone")]
        public long DamageDone { get; private set; }

        [JsonProperty("damageReceived")]
        public long DamageReceived { get; private set; }

        [JsonProperty("deaths")]
        public long Deaths { get; private set; }

        [JsonProperty("disablesDone")]
        public long DisablesDone { get; private set; }

        [JsonProperty("disablesReceived")]
        public long DisablesReceived { get; private set; }

        [JsonProperty("emote")]
        public long Emote { get; private set; }

        [JsonProperty("energyGained")]
        public long EnergyGained { get; private set; }

        [JsonProperty("energyUsed")]
        public long EnergyUsed { get; private set; }

        [JsonProperty("healingDone")]
        public long HealingDone { get; private set; }

        [JsonProperty("healingReceived")]
        public long HealingReceived { get; private set; }

        [JsonProperty("kills")]
        public long Kills { get; private set; }

        [JsonProperty("mount")]
        public long Mount { get; private set; }

        [JsonProperty("outfit")]
        public long Outfit { get; private set; }

        [JsonProperty("score")]
        public long Score { get; private set; }

        [JsonProperty("side")]
        public long Side { get; private set; }

        [JsonProperty("timeAlive")]
        public long TimeAlive { get; private set; }
    }
}