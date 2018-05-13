using System.Collections.Generic;

namespace Battlerite.NET.Rest.Parameters
{
    public class Paging
    {
        private readonly int limit;
        private readonly int offset;

        internal Paging(int offset, int limit)
        {
            this.offset = offset;
            this.limit = limit;
        }

        public static Paging Create(int offset, int limit)
        {
            return new Paging(offset, limit);
        }

        internal IEnumerable<IParameter> GetParameters()
        {
            return new List<IParameter>
            {
                new Parameter("page[offset]", offset.ToString()),
                new Parameter("page[limit]", limit.ToString())
            };
        }
    }
}