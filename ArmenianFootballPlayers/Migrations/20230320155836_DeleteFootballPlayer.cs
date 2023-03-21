using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmenianFootballPlayers.Migrations
{
    public partial class DeleteFootballPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE sp_DeleteFootballPlayer(
                                            @Id uniqueidentifier = null)
                                            AS
                                            BEGIN
                                            DELETE [dbo].Players
                                            WHERE Id = @Id
                                            END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE sp_DeleteFootballPlayer";
            migrationBuilder.Sql(procedure);
        }
    }
}
