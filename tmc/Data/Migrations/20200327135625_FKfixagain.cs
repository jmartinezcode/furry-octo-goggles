using Microsoft.EntityFrameworkCore.Migrations;

namespace tmc.Migrations
{
    public partial class FKfixagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieWatchlists_Movies_MovieId",
                table: "MovieWatchlists");

            migrationBuilder.DropIndex(
                name: "IX_MovieWatchlists_MovieId",
                table: "MovieWatchlists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MovieWatchlists_MovieId",
                table: "MovieWatchlists",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieWatchlists_Movies_MovieId",
                table: "MovieWatchlists",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
