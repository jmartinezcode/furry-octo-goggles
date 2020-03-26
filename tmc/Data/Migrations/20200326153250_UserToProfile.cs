using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmc.Data.Migrations
{
    public partial class UserToProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieRatings_SiteUsers_UserId",
                table: "MovieRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Watchlists_WatchlistId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Watchlists_SiteUsers_UserId",
                table: "Watchlists");

            migrationBuilder.DropTable(
                name: "SiteUsers");

            migrationBuilder.DropIndex(
                name: "IX_Watchlists_UserId",
                table: "Watchlists");

            migrationBuilder.DropIndex(
                name: "IX_Movies_WatchlistId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_MovieRatings_UserId",
                table: "MovieRatings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Watchlists");

            migrationBuilder.DropColumn(
                name: "WatchlistId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MovieRatings");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Watchlists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "MovieRatings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RatingDate",
                table: "MovieRatings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileName = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_ProfileId",
                table: "Watchlists",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRatings_ProfileId",
                table: "MovieRatings",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRatings_Profiles_ProfileId",
                table: "MovieRatings",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlists_Profiles_ProfileId",
                table: "Watchlists",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieRatings_Profiles_ProfileId",
                table: "MovieRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Watchlists_Profiles_ProfileId",
                table: "Watchlists");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Watchlists_ProfileId",
                table: "Watchlists");

            migrationBuilder.DropIndex(
                name: "IX_MovieRatings_ProfileId",
                table: "MovieRatings");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Watchlists");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "MovieRatings");

            migrationBuilder.DropColumn(
                name: "RatingDate",
                table: "MovieRatings");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Watchlists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WatchlistId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MovieRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SiteUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_UserId",
                table: "Watchlists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_WatchlistId",
                table: "Movies",
                column: "WatchlistId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRatings_UserId",
                table: "MovieRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteUsers_UserId",
                table: "SiteUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRatings_SiteUsers_UserId",
                table: "MovieRatings",
                column: "UserId",
                principalTable: "SiteUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Watchlists_WatchlistId",
                table: "Movies",
                column: "WatchlistId",
                principalTable: "Watchlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Watchlists_SiteUsers_UserId",
                table: "Watchlists",
                column: "UserId",
                principalTable: "SiteUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
