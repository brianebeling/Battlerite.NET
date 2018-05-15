using System.Collections.Generic;
using System.Linq;
using Battlerite.NET.Rest.Parameters;

namespace Battlerite.NET.Rest.Clients.Match.Builder
{
    public class MatchCollectionParameterBuilder
    {
        private FilterBuilder filter;
        private PagingBuilder pagingBuilder;
        private SortCriteria sortCriteria;
        private SortOrder sortOrder;

        // TODO Builder
        public MatchCollectionParameterBuilder WirthSorting(
            SortCriteria sortCriteria,
            SortOrder sortOrder = SortOrder.Ascending)
        {
            this.sortCriteria = sortCriteria;
            this.sortOrder = sortOrder;
            return this;
        }

        public FilterBuilder WithFilter()
        {
            filter = new FilterBuilder();
            return filter;
        }

        public PagingBuilder WithPaging()
        {
            pagingBuilder = new PagingBuilder();
            return pagingBuilder;
        }

        internal IEnumerable<IParameter> Build()
        {
            var parameterList = new List<IParameter>();

            var paging = pagingBuilder?.Build();

            if (paging != default(Paging))
                parameterList.AddRange(paging.GetParameters());


            // TODO Move this out of method
            if (sortCriteria != default(SortCriteria))
            {
                var prefix = string.Empty;

                if (sortOrder == SortOrder.Descending)
                    prefix = "-";

                parameterList.Add(
                    new Parameter(
                        "sort",
                        prefix +
                        char.ToLowerInvariant(sortCriteria.ToString().First()) +
                        sortCriteria.ToString().Substring(1)));
            }


            if (filter != default(FilterBuilder))
                parameterList.AddRange(filter.Build());

            return parameterList;
        }
    }
}