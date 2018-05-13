using Newtonsoft.Json;

namespace Battlerite.NET.Rest.DTOs.Matches.Rosters
{
    public class Stats
    {
        /// <summary>
        ///     Gets the amount of teams that individually queued up.
        ///     TODO research
        /// </summary>
        /// <value>
        ///     The size of the team.
        /// </value>
        [JsonProperty("teamSize")]
        public int IndividualTeamCount { get; private set; }

        public Region MatchRegion { get; }

        public PlacementGames PlacementGames { get; }

        public PreviousRanking PreviousRanking { get; }

        public Ranking Ranking { get; }

        public RankingChangeType RankingChangeType { get; }
        public RoundMetrics RoundMetrics { get; }

        public Season Season { get; }

        public Stats(
            int individualTeamCount,
            Region matchRegion,
            PlacementGames placementGames,
            PreviousRanking previousRanking,
            Ranking ranking,
            RankingChangeType rankingChangeType,
            RoundMetrics roundMetrics,
            Season season)
        {
            IndividualTeamCount = individualTeamCount;
            MatchRegion = matchRegion;
            PlacementGames = placementGames;
            PreviousRanking = previousRanking;
            Ranking = ranking;
            RankingChangeType = rankingChangeType;
            RoundMetrics = roundMetrics;
            Season = season;
        }
    }
}