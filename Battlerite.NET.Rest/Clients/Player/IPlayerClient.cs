using System.Collections.Generic;
using System.Threading.Tasks;
using Battlerite.NET.Rest.DTOs.Players;
using Optional;

namespace Battlerite.NET.Rest.Clients.Player
{
    public interface IPlayerClient
    {
        Task<Option<PopulatedPlayer>> GetPlayerByNameAsync(string playerName);
        Task<Option<PopulatedPlayer>> GetPlayerByPlayerIdAsync(long id);
        Task<Option<PopulatedPlayer>> GetPlayerBySteamIdAsync(ulong steamId);
        Task<Option<IReadOnlyList<PopulatedPlayer>>> GetPlayersByNameAsync(IEnumerable<string> playerNames);
        Task<Option<IReadOnlyList<PopulatedPlayer>>> GetPlayersByPlayerIdAsync(IEnumerable<long> playerIds);
        Task<Option<IReadOnlyList<PopulatedPlayer>>> GetPlayersBySteamIdAsync(IEnumerable<ulong> steamIds);
    }
}