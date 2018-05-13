using System;
using Battlerite.NET.Rest.Parameters;

namespace Battlerite.NET.Rest.Clients.Match.Builder
{
    public class PagingBuilder
    {
        private int limit = 5;
        private int offset;

        public PagingBuilder WithLimit(int limit)
        {
            if (limit < 1 || limit > 5)
                throw new ArgumentOutOfRangeException(
                    $"{nameof(limit)}",
                    "must be equal or greater than 1 and equal or less than 5");

            this.limit = limit;

            return this;
        }

        public PagingBuilder WithOffset(int offset)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException("Offset must be greater than 0");

            this.offset = offset;

            return this;
        }

        internal Paging Build()
        {
            return new Paging(offset, limit);
        }
    }
}