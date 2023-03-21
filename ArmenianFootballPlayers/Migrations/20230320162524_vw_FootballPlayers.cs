using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmenianFootballPlayers.Migrations
{
    public partial class vw_FootballPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string view = @"CREATE VIEW vw_FootballPlayers 
                            AS
                            SELECT * FROM Players";

            migrationBuilder.Sql(view);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP VIEW vw_FootballPlayers";
            migrationBuilder.Sql(procedure);
        }
    }
}
