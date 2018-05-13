using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Battlerite.NET.Rest.Clients.Match.Builder;

namespace Battlerite.NET.Rest.Clients.Match
{
    public interface IMatchClient
    {
        Task<DTOs.Matches.Match> GetMatchAsync(string id);

        Task<IEnumerable<DTOs.Matches.Match>> GetMatchCollectionAsync(
            Action<MatchCollectionParameterBuilder> parameterBuilder);
    }
}