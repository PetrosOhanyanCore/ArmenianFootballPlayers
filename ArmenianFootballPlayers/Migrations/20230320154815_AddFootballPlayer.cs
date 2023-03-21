using Microsoft.EntityFrameworkCore.Migrations;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

#nullable disable

namespace ArmenianFootballPlayers.Migrations
{
    public partial class AddFootballPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE sp_AddFootballPlayer(
                                    @Id uniqueidentifier = null,
                                    @Name nvarchar(40) = null,
                                    @Surname nvarchar(60) = null,
                                    @Number int = null,
                                    @IsPlaying bit = null,
                                    @Club nvarchar(70) = null,
                                    @Image nvarchar = null)
                                    AS
                                    BEGIN
                                    INSERT INTO[dbo].Players([Id],[Name],[Surname],[Number],[IsPlaying],[Club],[Image])
                                    VALUES(@Id, @Name, @Surname, @Number, @IsPlaying, @Club, @Image)
                                    END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE sp_AddFootballPlayer";
            migrationBuilder.Sql(procedure);
        }
    }
}
