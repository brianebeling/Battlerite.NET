using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.Requester
{
    public interface IRequester
    {
        Task<T> Request<T>(string request, JsonSerializerSettings jsonSerializerSettings);
    }
}