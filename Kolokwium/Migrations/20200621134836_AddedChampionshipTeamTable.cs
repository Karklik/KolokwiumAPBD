using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium.Migrations
{
    public partial class AddedChampionshipTeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Championship_Team",
                columns: table => new
                {
                    IdTeam = table.Column<int>(nullable: false),
                    IdChampionship = table.Column<int>(nullable: false),
                    Score = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship_Team", x => new { x.IdTeam, x.IdChampionship });
                    table.ForeignKey(
                        name: "FK_Championship_Team_Championship_IdChampionship",
                        column: x => x.IdChampionship,
                        principalTable: "Championship",
                        principalColumn: "IdChamptionship",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Championship_Team_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Championship_Team_IdChampionship",
                table: "Championship_Team",
                column: "IdChampionship");

            migrationBuilder.CreateIndex(
                name: "IX_Championship_Team_IdTeam",
                table: "Championship_Team",
                column: "IdTeam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Championship_Team");
        }
    }
}
