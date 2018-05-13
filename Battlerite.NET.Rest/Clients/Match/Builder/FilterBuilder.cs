using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Battlerite.NET.Rest.DTOs.Matches;
using Battlerite.NET.Rest.Parameters;
using Battlerite.NET.Rest.Parameters.Filter;

namespace Battlerite.NET.Rest.Clients.Match.Builder
{
    public class FilterBuilder
    {
        private IEnumerable<string> patchVersions;
        private IEnumerable<int> playerIds;
        private RankingType rankingType;
        private ServerType serverType;
        private FilterTimeSpanOffset timeSpanOffset;

        public static IEnumerable<Enum> GetFlags(Enum e)
        {
            return Enum.GetValues(e.GetType()).Cast<Enum>().Where(e.HasFlag);
        }

        public static IEnumerable<Enum> GetFlagsWithNoneValue(Enum e)
        {
            return Enum.GetValues(e.GetType()).Cast<Enum>().Where(v => !Equals((int) (object) v, 0) && e.HasFlag(v));
        }

        public FilterBuilder ByPatchVersions(IEnumerable<string> patchVersions)
        {
            this.patchVersions = patchVersions;
            return this;
        }

        public FilterBuilder ByPlayerIds(IEnumerable<int> playerIds)
        {
            this.playerIds = playerIds;
            return this;
        }

        public FilterBuilder ByRankingType(RankingType rankingTypes)
        {
            rankingType = rankingTypes;
            return this;
        }

        public FilterBuilder ByServerType(ServerType serverTypes)
        {
            serverType = serverTypes;
            return this;
        }

        public FilterBuilder ByTimeSpanOffset(FilterTimeSpanOffset timeSpanOffset)
        {
            this.timeSpanOffset = timeSpanOffset;
            return this;
        }

        internal IEnumerable<IParameter> Build()
        {
            var parameterList = new List<IParameter>();

            if (timeSpanOffset != default(FilterTimeSpanOffset))
            {
                var (start, end) = timeSpanOffset.Get();
                parameterList.Add(
                    new Parameter(
                        "filter[createdAt-Start]",
                        start.ToString("s", CultureInfo.InvariantCulture)));
                parameterList.Add(
                    new Parameter(
                        "filter[createdAt-End]",
                        end.ToString("s", CultureInfo.InvariantCulture)));
            }

            AddParameters("playerIds", playerIds);
            AddParameters("patchVersion", patchVersions);

            var serverTypeValues = GetFlags(serverType);

            AddParameters("serverType", serverTypeValues);

            var rankingTypeValues = GetFlagsWithNoneValue(rankingType);

            AddParameters("rankingType", rankingTypeValues);

            return parameterList;

            void AddParameters<T>(string filterName, IEnumerable<T> parameters)
            {
                if (parameters != null)
                    parameterList.Add(new Parameter($"filter[{filterName}]", string.Join(",", parameters)));
            }
        }
    }
}