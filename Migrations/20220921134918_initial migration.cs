using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    BannerUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    YearsPlaying = table.Column<int>(type: "INTEGER", nullable: false),
                    Discord = table.Column<string>(type: "TEXT", nullable: false),
                    WeekDays = table.Column<string>(type: "TEXT", nullable: false),
                    HourStart = table.Column<int>(type: "INTEGER", nullable: false),
                    HourEnd = table.Column<int>(type: "INTEGER", nullable: false),
                    UseVoiceChannel = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')"),
                    GameId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ads_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "BannerUrl", "Title" },
                values: new object[] { new Guid("3603085e-3dcd-427b-8439-9d0fa323e4db"), "https://static-cdn.jtvnw.net/ttv-boxart/32399_IGDB-188x250.jpg", "Counter-Strike" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "BannerUrl", "Title" },
                values: new object[] { new Guid("486d3535-bed8-43f6-84fa-08abeacd1d97"), "https://static-cdn.jtvnw.net/ttv-boxart/511224-285x380.jpg", "Apex Legends" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "BannerUrl", "Title" },
                values: new object[] { new Guid("60f30faa-550e-4feb-9b33-117d83d23c3c"), "https://static-cdn.jtvnw.net/ttv-boxart/33214-285x380.jpg", "Fortnite" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "BannerUrl", "Title" },
                values: new object[] { new Guid("839d57c9-5553-4b14-84c2-071e0e4aa187"), "https://static-cdn.jtvnw.net/ttv-boxart/18122-285x380.jpg", "World of Warcraft" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "BannerUrl", "Title" },
                values: new object[] { new Guid("a29c34f1-ce82-4ef0-84bf-68989b43a4fc"), "https://static-cdn.jtvnw.net/ttv-boxart/21779-188x250.jpg", "League of Legends" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "BannerUrl", "Title" },
                values: new object[] { new Guid("d0ea20ba-73fd-42dd-8ee9-794c5b14c02a"), "https://static-cdn.jtvnw.net/ttv-boxart/516575-188x250.jpg", "Valorant" });

            migrationBuilder.InsertData(
                table: "Ads",
                columns: new[] { "Id", "CreatedAt", "Discord", "GameId", "HourEnd", "HourStart", "Name", "UseVoiceChannel", "WeekDays", "YearsPlaying" },
                values: new object[] { new Guid("9ecf5dff-5a5a-421e-a3fd-deb96d560f4d"), new DateTime(2022, 9, 21, 10, 49, 18, 601, DateTimeKind.Local).AddTicks(1940), "Xablau", new Guid("a29c34f1-ce82-4ef0-84bf-68989b43a4fc"), 1260, 1080, "bbJoinha", true, "[0,1,2,3,4,5,6]", 12 });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_GameId",
                table: "Ads",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
