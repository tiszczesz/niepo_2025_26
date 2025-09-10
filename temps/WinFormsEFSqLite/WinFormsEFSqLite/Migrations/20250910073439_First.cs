using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WinFormsEFSqLite.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    PubishDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PubishDate", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", new DateTime(2008, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code" },
                    { 2, "Andrew Hunt, David Thomas", new DateTime(1999, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Pragmatic Programmer" },
                    { 3, "Erich Gamma et al.", new DateTime(1994, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Design Patterns" },
                    { 4, "Martin Fowler", new DateTime(1999, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Refactoring" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
