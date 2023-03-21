using ArmenianFootballPlayers.Models;

namespace ArmenianFootballPlayers.DataLayer.IRepository
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetPlayersAsync(OrderFilterPagination orderFilterPagination);
        Task AddPlayerAsync(Player player);
        Task RemovePlayerAsync(Guid playerId);
        Task UpdatePlayerAsync(Player player);
    }
}
