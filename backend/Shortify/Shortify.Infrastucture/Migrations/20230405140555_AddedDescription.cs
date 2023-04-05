using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shortify.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "AlgorithmDescriptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlgorithmDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlgorithmDescriptions_Users_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlgorithmDescriptions_LastModifiedById",
                table: "AlgorithmDescriptions",
                column: "LastModifiedById",
                unique: true,
                filter: "[LastModifiedById] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlgorithmDescriptions");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
