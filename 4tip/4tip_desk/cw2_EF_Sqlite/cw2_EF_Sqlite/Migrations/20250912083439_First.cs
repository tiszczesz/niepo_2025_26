using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cw2_EF_Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Group = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "FirstName", "Group", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "1A", "Kowalski" },
                    { 2, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna", "2B", "Nowak" },
                    { 3, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piotr", "1A", "Zieliński" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
