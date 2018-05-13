using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Battlerite.NET.Rest.RateLimit
{
    public interface IRateLimitPolicy
    {
        Task ApplyRateLimitAsync(HttpHeaders httpResponseHeaders);
    }
}