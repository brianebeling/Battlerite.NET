using System;

namespace Battlerite.NET.Rest.Parameters.Filter
{
    public class FilterTimeSpanOffset
    {
        private readonly TimeSpan range;
        private readonly DateTime start;

        internal FilterTimeSpanOffset(DateTime start, TimeSpan range)
        {
            this.start = start;
            this.range = range;
        }

        public static FilterTimeSpanOffset Create(DateTime start, TimeSpan range)
        {
            return new FilterTimeSpanOffset(start, range);
        }

        // TODO more factory methods

        internal (DateTimeOffset start, DateTimeOffset end) Get()
        {
            return (start, start + range);
        }
    }
}