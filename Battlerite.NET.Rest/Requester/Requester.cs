using System.Net.Http;
using System.Threading.Tasks;
using Battlerite.NET.Rest.RateLimit;
using Newtonsoft.Json;

namespace Battlerite.NET.Rest.Requester
{
    public class Requester : IRequester
    {
        private readonly HttpClient httpClient;
        private readonly IRateLimitPolicy rateLimitPolicy;
        private HttpResponseMessage lastResponse;

        public Requester(HttpClient httpClient, IRateLimitPolicy rateLimitPolicy)
        {
            this.httpClient = httpClient;
            this.rateLimitPolicy = rateLimitPolicy;
        }

        public async Task<T> Request<T>(string request, JsonSerializerSettings jsonSerializerSettings)
        {
            lastResponse = await httpClient.GetAsync(request);

            await rateLimitPolicy.ApplyRateLimitAsync(lastResponse.Headers);

            var responseText = await lastResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseText, jsonSerializerSettings);
        }
    }
}