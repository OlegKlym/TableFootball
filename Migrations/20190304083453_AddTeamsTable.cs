using Microsoft.EntityFrameworkCore.Migrations;

namespace TableFootball.Migrations
{
    public partial class AddTeamsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_TeamEntity_TeamEntityTeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamEntity_Games_GameId",
                table: "TeamEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamEntity",
                table: "TeamEntity");

            migrationBuilder.RenameTable(
                name: "TeamEntity",
                newName: "Teams");

            migrationBuilder.RenameIndex(
                name: "IX_TeamEntity_GameId",
                table: "Teams",
                newName: "IX_Teams_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamEntityTeamId",
                table: "Players",
                column: "TeamEntityTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Games_GameId",
                table: "Teams",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamEntityTeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Games_GameId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "TeamEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_GameId",
                table: "TeamEntity",
                newName: "IX_TeamEntity_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamEntity",
                table: "TeamEntity",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_TeamEntity_TeamEntityTeamId",
                table: "Players",
                column: "TeamEntityTeamId",
                principalTable: "TeamEntity",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamEntity_Games_GameId",
                table: "TeamEntity",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
