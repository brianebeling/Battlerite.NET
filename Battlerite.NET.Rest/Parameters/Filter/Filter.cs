using System.Collections.Generic;
using Battlerite.NET.Rest.DTOs.Matches;

namespace Battlerite.NET.Rest.Parameters.Filter
{
    public class Filter
    {
        public IEnumerable<string> PatchVersions { get; set; }
        public IEnumerable<int> PlayerIds { get; set; }
        public IEnumerable<RankingType> RankingTypes { get; set; }
        public IEnumerable<ServerType> ServerTypes { get; set; }
        public FilterTimeSpanOffset TimeSpanOffset { get; set; }
    }
}