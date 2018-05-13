using System.Collections.Generic;
using Newtonsoft.Json;

namespace Battlerite.NET.Assets.Stackables
{
    internal class Stackables
    {
        [JsonProperty("Mappings")]
        public IEnumerable<Mapping> Mappings { get; private set; }
    }
}