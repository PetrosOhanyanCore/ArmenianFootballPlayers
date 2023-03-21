using ArmenianFootballPlayers.BusinessLayer.IService;
using ArmenianFootballPlayers.DataLayer;
using ArmenianFootballPlayers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArmenianFootballPlayers.Controllers
{
    public class FootballPlayersController : Controller
    {
        private readonly IPlayerService _playerService;

        public FootballPlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(OrderFilterPagination orderFilterPagination)
        {
            var players = await _playerService.GetPlayersAsync(orderFilterPagination);

            PlayersVM playersVM = new()
            {
                OrderFilterPagination = orderFilterPagination,
                Players = players
            };

            return View(playersVM);            
        }


        [HttpPost]
        public async Task<JsonResult> GetFilteredPage([FromBody]OrderFilterPagination orderFilterPagination)
        {
            var players = await _playerService.GetPlayersAsync(orderFilterPagination);
            OrderFilterPagination pagination = orderFilterPagination;
            PlayersVM playersVM = new()
            {
                Players = players,
                OrderFilterPagination = pagination
            };
            return Json(playersVM);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Player player)
        {
            var newPlayer = new Player
            {
                Id = new Guid(),
                Name = player.Name,
                Surname = player.Surname,
                Number = player.Number,
                Club = player.Club,
                IsPlaying = player.IsPlaying,
                Image = player.Image
            };
            await _playerService.AddPlayerAsync(newPlayer);

            return RedirectToAction("Index");
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Player player)
        {
            try
            {
                var editedPlayer = new Player
                {
                    Id = new Guid(),
                    Name = player.Name,
                    Surname = player.Surname,
                    Number = player.Number,
                    Club = player.Club,
                    IsPlaying = player.IsPlaying,
                    Image = player.Image
                };
                await _playerService.UpdatePlayerAsync(editedPlayer);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                RedirectToAction("Index", ex.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid playerId)
        {
            try
            {
                await _playerService.RemovePlayerAsync(playerId);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                RedirectToAction("Index", ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
