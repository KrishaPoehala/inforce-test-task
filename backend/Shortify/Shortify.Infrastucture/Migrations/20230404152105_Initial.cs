using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shortify.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShortenedUrls",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OriginalUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortenedUrl = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortenedUrls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShortenedUrls_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortenedUrls_CreatedById",
                table: "ShortenedUrls",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ShortenedUrls_ShortenedUrl",
                table: "ShortenedUrls",
                column: "ShortenedUrl",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortenedUrls");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
