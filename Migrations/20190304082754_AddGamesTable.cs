using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TableFootball.Migrations
{
    public partial class AddGamesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamEntityTeamId",
                table: "Players",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<string>(nullable: true),
                    TeamWinnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "TeamEntity",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamEntity", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_TeamEntity_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamEntityTeamId",
                table: "Players",
                column: "TeamEntityTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamEntity_GameId",
                table: "TeamEntity",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_TeamEntity_TeamEntityTeamId",
                table: "Players",
                column: "TeamEntityTeamId",
                principalTable: "TeamEntity",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_TeamEntity_TeamEntityTeamId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "TeamEntity");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamEntityTeamId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamEntityTeamId",
                table: "Players");
        }
    }
}
