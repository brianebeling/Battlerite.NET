using System;
using Battlerite.NET.Rest.DTOs.Matches.Rosters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Battlerite.NET.Rest.Converters
{
    public class StatsJsonConverter : JsonConverter<Stats>
    {
        public override bool CanWrite { get; } = false;

        public override Stats ReadJson(
            JsonReader reader,
            Type objectType,
            Stats existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            // TODO Make future proof, aka. Error Handling, Null Values..
            var jObject = JObject.Load(reader);

            if (jObject == null)
                return null;

            var individualTeamCount = jObject["teamSize"].ToObject<int>();

            var jTokenMatchRegion = jObject["matchRegion"];
            var region = jTokenMatchRegion.ToObject<Region>();

            var placementGames = jObject.ToObject<PlacementGames>();

            var previousRanking = jObject.ToObject<PreviousRanking>();

            var ranking = jObject.ToObject<Ranking>();

            var jTokenRankingChangeType = jObject["rankingChangeType"];

            var rankingChangeType = jTokenRankingChangeType.ToObject<RankingChangeType>();

            var roundMetrics = jObject.ToObject<RoundMetrics>();

            // TODO: this is like, not good.. fix it, please
            var season = new Season(jObject.ToObject<RosterMetrics>(), jObject["season"].ToObject<int?>());

            var stats = new Stats(
                individualTeamCount,
                region,
                placementGames,
                previousRanking,
                ranking,
                rankingChangeType,
                roundMetrics,
                season);

            return stats;
        }

        public override void WriteJson(JsonWriter writer, Stats value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}