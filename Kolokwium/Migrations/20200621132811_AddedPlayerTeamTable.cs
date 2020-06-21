using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium.Migrations
{
    public partial class AddedPlayerTeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player_Team",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(nullable: false),
                    IdTeam = table.Column<int>(nullable: false),
                    NumOnShirt = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Team", x => new { x.IdPlayer, x.IdTeam });
                    table.ForeignKey(
                        name: "FK_Player_Team_Player_IdPlayer",
                        column: x => x.IdPlayer,
                        principalTable: "Player",
                        principalColumn: "IdPlayer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_Team_IdPlayer",
                table: "Player_Team",
                column: "IdPlayer");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Team_IdTeam",
                table: "Player_Team",
                column: "IdTeam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player_Team");
        }
    }
}
