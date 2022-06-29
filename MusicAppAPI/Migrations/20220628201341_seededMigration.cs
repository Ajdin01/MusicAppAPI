using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAppAPI.Migrations
{
    public partial class seededMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SongUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SongRating = table.Column<int>(type: "int", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    SongEntered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SongEdited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username", "VerificationToken", "VerifiedAt" },
                values: new object[] { 1, new byte[] { 68, 108, 90, 77, 84, 86, 49, 105, 56, 84, 72, 89, 99, 47, 56, 84, 119, 87, 99, 55, 89, 108, 76, 76, 56, 100, 48, 88, 67, 109, 76, 80, 48, 82, 121, 88, 74, 66, 120, 109, 43, 69, 85, 102, 111, 71, 100, 73, 99, 117, 70, 51, 57, 56, 65, 120, 48, 112, 88, 76, 104, 56, 90, 85, 115, 65, 67, 101, 84, 98, 90, 107, 52, 43, 85, 68, 80, 71, 116, 117, 90, 69, 86, 97, 107, 103, 61, 61 }, new byte[] { 47, 122, 66, 114, 117, 101, 101, 88, 100, 109, 67, 77, 50, 78, 86, 66, 97, 98, 112, 71, 113, 113, 120, 120, 47, 88, 69, 48, 56, 114, 107, 116, 52, 43, 106, 80, 84, 49, 77, 107, 52, 79, 110, 43, 74, 122, 83, 51, 43, 76, 71, 111, 78, 77, 83, 99, 49, 106, 103, 97, 66, 52, 99, 87, 83, 100, 109, 120, 101, 71, 57, 98, 100, 67, 118, 75, 119, 104, 74, 98, 97, 117, 114, 101, 85, 43, 120, 66, 80, 120, 75, 104, 90, 98, 67, 57, 49, 121, 107, 69, 55, 115, 80, 112, 72, 85, 109, 119, 102, 70, 78, 47, 88, 84, 68, 83, 70, 48, 82, 66, 108, 121, 48, 119, 100, 50, 116, 77, 66, 111, 67, 56, 105, 54, 85, 111, 90, 76, 101, 110, 57, 77, 65, 98, 111, 115, 76, 70, 49, 85, 72, 77, 73, 97, 49, 112, 80, 69, 122, 112, 89, 111, 105, 102, 115, 85, 57, 77, 79, 84, 115, 61 }, "TestUser", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username", "VerificationToken", "VerifiedAt" },
                values: new object[] { 2, new byte[] { 68, 108, 90, 77, 84, 86, 49, 105, 56, 84, 72, 89, 99, 47, 56, 84, 119, 87, 99, 55, 89, 108, 76, 76, 56, 100, 48, 88, 67, 109, 76, 80, 48, 82, 121, 88, 74, 66, 120, 109, 43, 69, 85, 102, 111, 71, 100, 73, 99, 117, 70, 51, 57, 56, 65, 120, 48, 112, 88, 76, 104, 56, 90, 85, 115, 65, 67, 101, 84, 98, 90, 107, 52, 43, 85, 68, 80, 71, 116, 117, 90, 69, 86, 97, 107, 103, 61, 61 }, new byte[] { 47, 122, 66, 114, 117, 101, 101, 88, 100, 109, 67, 77, 50, 78, 86, 66, 97, 98, 112, 71, 113, 113, 120, 120, 47, 88, 69, 48, 56, 114, 107, 116, 52, 43, 106, 80, 84, 49, 77, 107, 52, 79, 110, 43, 74, 122, 83, 51, 43, 76, 71, 111, 78, 77, 83, 99, 49, 106, 103, 97, 66, 52, 99, 87, 83, 100, 109, 120, 101, 71, 57, 98, 100, 67, 118, 75, 119, 104, 74, 98, 97, 117, 114, 101, 85, 43, 120, 66, 80, 120, 75, 104, 90, 98, 67, 57, 49, 121, 107, 69, 55, 115, 80, 112, 72, 85, 109, 119, 102, 70, 78, 47, 88, 84, 68, 83, 70, 48, 82, 66, 108, 121, 48, 119, 100, 50, 116, 77, 66, 111, 67, 56, 105, 54, 85, 111, 90, 76, 101, 110, 57, 77, 65, 98, 111, 115, 76, 70, 49, 85, 72, 77, 73, 97, 49, 112, 80, 69, 122, 112, 89, 111, 105, 102, 115, 85, 57, 77, 79, 84, 115, 61 }, "Ajdin", null, null });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "ArtistName", "IsFavorite", "SongEdited", "SongEntered", "SongName", "SongRating", "SongUrl", "UserId" },
                values: new object[] { 1, "TestArtist", true, new DateTime(2022, 6, 28, 22, 13, 41, 510, DateTimeKind.Local).AddTicks(1372), new DateTime(2022, 6, 28, 22, 13, 41, 510, DateTimeKind.Local).AddTicks(1370), "TestSong", 4, "testURL", 1 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "ArtistName", "IsFavorite", "SongEdited", "SongEntered", "SongName", "SongRating", "SongUrl", "UserId" },
                values: new object[] { 2, "TestArtist2", false, new DateTime(2022, 6, 28, 22, 13, 41, 510, DateTimeKind.Local).AddTicks(1379), new DateTime(2022, 6, 28, 22, 13, 41, 510, DateTimeKind.Local).AddTicks(1377), "TestSong2", 2, "testURL2", 1 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "ArtistName", "IsFavorite", "SongEdited", "SongEntered", "SongName", "SongRating", "SongUrl", "UserId" },
                values: new object[] { 3, "TestArtist3", true, new DateTime(2022, 6, 28, 22, 13, 41, 510, DateTimeKind.Local).AddTicks(1385), new DateTime(2022, 6, 28, 22, 13, 41, 510, DateTimeKind.Local).AddTicks(1384), "TestSong3", 5, "testURL3", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_UserId",
                table: "Songs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
