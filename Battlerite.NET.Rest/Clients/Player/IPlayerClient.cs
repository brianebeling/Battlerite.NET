using System.Collections.Generic;
using System.Threading.Tasks;
using Battlerite.NET.Rest.DTOs.Players;

namespace Battlerite.NET.Rest.Clients.Player
{
    public interface IPlayerClient
    {
        Task<PopulatedPlayer> GetPlayerByPlayerIdAsync(long id);
        Task<IReadOnlyList<PopulatedPlayer>> GetPlayersByNameAsync(IEnumerable<string> playerNames);
        Task<IReadOnlyList<PopulatedPlayer>> GetPlayersByPlayerIdAsync(IEnumerable<long> playerIds);
        Task<IReadOnlyList<PopulatedPlayer>> GetPlayersBySteamIdAsync(IEnumerable<ulong> steamIds);
    }
}