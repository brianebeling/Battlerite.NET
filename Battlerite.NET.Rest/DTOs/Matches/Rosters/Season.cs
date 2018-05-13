namespace Battlerite.NET.Rest.DTOs.Matches.Rosters
{
    public class Season
    {
        public RosterMetrics Metrics { get; }

        public int? Value { get; }

        public Season(RosterMetrics metrics, int? value)
        {
            Metrics = metrics;
            Value = value;
        }
    }
}