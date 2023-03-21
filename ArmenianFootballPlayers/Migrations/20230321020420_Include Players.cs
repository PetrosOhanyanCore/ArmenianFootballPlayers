using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmenianFootballPlayers.Migrations
{
    public partial class IncludePlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"INSERT INTO [FootballPlayersDb].[dbo].[Players] VALUES
                        ('22afbc02-cf84-481c-80dc-7827b63cb491','Lucas','Zelarayan',10,1,'Columbus Crew',''),
                        ('477ad575-e1ef-4e0e-8a36-946bc2c7c202','Tigran','Barseghyan',11,1,'Slovan Bratislava',''),
                        ('5ec3c87e-a4ec-45f8-a390-6a8609be58bb','Khoren','Bayramyan',7,1,'FK Rostov','')";

            migrationBuilder.Sql(sql);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
