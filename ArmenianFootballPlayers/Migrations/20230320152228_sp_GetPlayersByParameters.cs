using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmenianFootballPlayers.Migrations
{
    public partial class sp_GetPlayersByParameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE sp_GetPlayersByParameters(
									@ItemInPage int = 0,
									@PageNumber int = 0,
									@SortString nvarchar(1000) = null,
									@SearchByName nvarchar(40) = '%',
									@SearchBySurName nvarchar(60) = '%',
									@SearchByNumber int = null,
									@SearchByIsPlaying bit = null,
									@SearchByClub nvarchar(70) = '%'	)
								AS
								BEGIN
									SELECT *
									FROM [FootballPlayersDb].[dbo].[vw_FootballPlayers]
									WHERE [Name] LIKE ISNULL('%'+@SearchByName+'%',[Name])
									AND [Surname] LIKE ISNULL('%'+@SearchBySurName+'%',[Surname])
									AND [Number] = ISNULL(@SearchByNumber,[Number])
									AND [IsPlaying] = ISNULL(@SearchByIsPlaying,[IsPlaying])
									AND [Club] LIKE ISNULL('%'+@SearchByClub+'%',[Club])
									ORDER BY ISNULL(@SortString,[Id])	
									OFFSET (@ItemInPage*(@PageNumber-1))  ROWS
									FETCH NEXT @ItemInPage ROWS ONLY;
								END";
			migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			string procedure = @"DROP PROCEDURE sp_GetPlayersByParameters";
			migrationBuilder.Sql(procedure);
        }
    }
}
