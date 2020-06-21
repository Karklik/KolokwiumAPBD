using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Kolokwium.Migrations
{
    public partial class AddedTeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    IdTeam = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamName = table.Column<string>(maxLength: 30, nullable: false),
                    MaxAge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.IdTeam);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_Team_IdTeam",
                table: "Player_Team",
                column: "IdTeam",
                principalTable: "Team",
                principalColumn: "IdTeam",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_Team_IdTeam",
                table: "Player_Team");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
