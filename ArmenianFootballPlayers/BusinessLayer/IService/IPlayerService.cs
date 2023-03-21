using ArmenianFootballPlayers.Models;

namespace ArmenianFootballPlayers.BusinessLayer.IService
{
    public interface IPlayerService
    {
        Task<List<Player>> GetPlayersAsync(OrderFilterPagination orderFilterPagination);
        Task AddPlayerAsync(Player player);
        Task RemovePlayerAsync(Guid playerId);
        Task UpdatePlayerAsync(Player player);
    }
}
