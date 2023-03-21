using ArmenianFootballPlayers.DataLayer.IRepository;
using ArmenianFootballPlayers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ArmenianFootballPlayers.DataLayer.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        public readonly FootballDbContext _context;

        #region Local variables for generate query for sorting

        private string generatedQuery { get; set; }

        private bool? sortedByName { get; set; }
        private bool? sortedBySurname { get; set; }
        private bool? sortedByNumber { get; set; }
        private bool? sortedByIsPlaying { get; set; }
        private bool? sortedByClub { get; set; }
        private List<string> Sorts { get; set; }

        #endregion

        public PlayerRepository(FootballDbContext context)
        {
            _context = context;
        }


        public async Task AddPlayerAsync(Player player)
        {
            _context.Players.FromSqlRaw<Player>
                ("sp_AddFootballPlayer {0},{1},{2},{3},{4},{5},{6}",
                player.Id, player.Name, player.Surname, player.Number,
                player.IsPlaying, player.Club, player.Image);
        }

        public async Task<List<Player>> GetPlayersAsync(OrderFilterPagination orderFilterPagination)
        {
            string sortStringBuild = SortStringBuilder(orderFilterPagination.SortString);

            var result = await _context.Players.FromSqlRaw<Player>
                ("sp_GetPlayersByParameters {0},{1},{2},{3},{4},{5},{6},{7}",
                orderFilterPagination.ItemInPage,
                orderFilterPagination.PageNumber,
                sortStringBuild,
                orderFilterPagination.SearchByName,
                orderFilterPagination.SearchBySurName,
                orderFilterPagination.SearchByNumber,
                orderFilterPagination.SearchByIsPlaying,
                orderFilterPagination.SearchByClub)
                .ToListAsync();
            return result;
        }


        public async Task RemovePlayerAsync(Guid playerId)
        {
            _context.Players.FromSqlRaw<Player>
                ("sp_DeleteFootballPlayer {0}", playerId);
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            _context.Players.FromSqlRaw<Player>
                 ("sp_EditFootballPlayer {0},{1},{2},{3},{4},{5},{6}",
                 player.Id, player.Name, player.Surname, player.Number,
                 player.IsPlaying, player.Club, player.Image);
        }



        private string SortStringBuilder(string? sortString)
        {
            if (sortString == null)
                return null;

            else if (sortString == "Name")
                if (sortedByName == true)
                {
                    sortedByName = false;
                    var index = Sorts.FindIndex(c => c == "Name");
                    Sorts[index] = "Name DESC";
                }
                else if (sortedByName == false)
                {
                    sortedByName = null;
                    Sorts.Remove("Name DESC");
                }
                else
                {
                    sortedByName = true;
                    Sorts.Add("Name");
                }



            else if (sortString == "Surname")
                if (sortedBySurname == true)
                {
                    sortedBySurname = false;
                    var index = Sorts.FindIndex(c => c == "Surname");
                    Sorts[index] = "Surname DESC";
                }
                else if (sortedBySurname == false)
                {
                    sortedBySurname = null;
                    Sorts.Remove("Surname DESC");
                }
                else
                {
                    sortedBySurname = true;
                    Sorts.Add("Surname");
                }



            else if (sortString == "Number")
                if (sortedByNumber == true)
                {
                    sortedByNumber = false;
                    var index = Sorts.FindIndex(c => c == "Number");
                    Sorts[index] = "Number DESC";
                }
                else if (sortedByNumber == false)
                {
                    sortedByNumber = null;
                    Sorts.Remove("Number DESC");
                }
                else
                {
                    sortedByNumber = true;
                    Sorts.Add("Number");
                }



            else if (sortString == "IsPlaying")
                if (sortedByIsPlaying == true)
                {
                    sortedByIsPlaying = false;
                    var index = Sorts.FindIndex(c => c == "IsPlaying");
                    Sorts[index] = "IsPlaying DESC";
                }
                else if (sortedByIsPlaying == false)
                {
                    sortedByIsPlaying = null;
                    Sorts.Remove("IsPlaying DESC");
                }
                else
                {
                    sortedByIsPlaying = true;
                    Sorts.Add("IsPlaying");
                }



            else if (sortString == "Club")
                if (sortedByClub == true)
                {
                    sortedByClub = false;
                    var index = Sorts.FindIndex(c => c == "Club");
                    Sorts[index] = "Club DESC";
                }
                else if (sortedByClub == false)
                {
                    sortedByClub = null;
                    Sorts.Remove("Club DESC");
                }
                else
                {
                    sortedByClub = true;
                    Sorts.Add("Club");
                }
                    


            foreach (var sortName in Sorts)
            {
                generatedQuery = $"{generatedQuery} + {sortedByName}";
                if (sortName != Sorts.LastOrDefault())
                    generatedQuery = $"{generatedQuery} + ,";
            }



            return generatedQuery;
        }
    }
}
