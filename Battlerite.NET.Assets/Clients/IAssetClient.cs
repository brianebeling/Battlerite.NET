using System.Collections.Generic;
using System.Threading.Tasks;
using Battlerite.NET.Assets.Stackables;

namespace Battlerite.NET.Assets.Clients
{
    public interface IAssetClient
    {
        Task<IReadOnlyDictionary<long, Mapping>> GetStackablesAsync(string revision);

        Task<IReadOnlyDictionary<long, Mapping>> GetStackablesAsync();
    }
}