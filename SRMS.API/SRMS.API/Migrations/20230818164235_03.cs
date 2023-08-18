using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SRMS.API.Migrations
{
    /// <inheritdoc />
    public partial class _03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "LevelId", "Description", "IsActive", "LevelName" },
                values: new object[,]
                {
                    { 1, "Level for basic learners", true, "Basic" },
                    { 2, "Level for advance learners", true, "Advance" },
                    { 3, "Level for full level learners", true, "Full Level" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: 3);
        }
    }
}
