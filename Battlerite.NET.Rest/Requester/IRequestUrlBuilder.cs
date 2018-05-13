using System.Collections.Generic;
using Battlerite.NET.Rest.Parameters;

namespace Battlerite.NET.Rest.Requester
{
    public interface IRequestUrlBuilder
    {
        string Build(
            string apiEndPoint,
            IEnumerable<IParameter> parameters = null);
    }
}