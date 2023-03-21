using ArmenianFootballPlayers.BusinessLayer.IService;
using ArmenianFootballPlayers.DataLayer.IRepository;
using ArmenianFootballPlayers.Models;

namespace ArmenianFootballPlayers.BusinessLayer.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        
        public Task AddPlayerAsync(Player player)
        {
            return _playerRepository.AddPlayerAsync(player);
        }

        public Task<List<Player>> GetPlayersAsync(OrderFilterPagination orderFilterPagination)
        {
            return _playerRepository.GetPlayersAsync(orderFilterPagination);
        }

        public Task RemovePlayerAsync(Guid playerId)
        {
            return _playerRepository.RemovePlayerAsync(playerId);
        }

        public Task UpdatePlayerAsync(Player player)
        {
            return _playerRepository.UpdatePlayerAsync(player);
        }
    }
}
