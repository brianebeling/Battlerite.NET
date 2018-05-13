using System.Collections.Generic;
using System.Linq;
using Battlerite.NET.Rest.Parameters;

namespace Battlerite.NET.Rest.Requester
{
    public class RequestUrlBuilder : IRequestUrlBuilder
    {
        private readonly string baseAdress;

        private readonly IEnumerable<IParameter> reoccuringParameters;

        internal RequestUrlBuilder(string baseAdress, IEnumerable<IParameter> reoccuringParameters)
        {
            this.baseAdress = baseAdress;
            this.reoccuringParameters = reoccuringParameters;
        }

        public string Build(string apiEndPoint, IEnumerable<IParameter> parameters = null)
        {
            var value = baseAdress + apiEndPoint;

            var @params = new List<IParameter>();

            if (reoccuringParameters != null)
                @params.AddRange(reoccuringParameters);

            if (parameters != null)
                @params.AddRange(parameters);

            if (!@params.Any())
                return value;

            var first = @params.First();

            value += "?" + first.Get();

            @params.Remove(first);

            var aggregate = @params.Aggregate(
                value,
                (current, param) => current + "&" + param.Get());

            return aggregate;
        }
    }
}