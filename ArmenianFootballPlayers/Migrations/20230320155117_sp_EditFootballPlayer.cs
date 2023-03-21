using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmenianFootballPlayers.Migrations
{
    public partial class sp_EditFootballPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE sp_EditFootballPlayer(
												@Id uniqueidentifier = null,
												@Name nvarchar(40) = null,
												@Surname nvarchar(60) = null,
												@Number int = null,
												@IsPlaying bit = null,
												@Club nvarchar(70) = null,
												@Image nvarchar = null)
										AS
										BEGIN
												UPDATE [dbo].Players
												SET [Name] = @Name,
												[Surname] = @Surname,
												[Number] =@Number,
												[IsPlaying] = @IsPlaying,
												[Club] = @Club,
												[Image] = @Image
												WHERE Id = @Id
										END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE sp_EditFootballPlayer";
            migrationBuilder.Sql(procedure);
        }
    }
}
