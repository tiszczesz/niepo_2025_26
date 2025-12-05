using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cw4_school2025.Migrations
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
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EctsPoints = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "EctsPoints", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Jan", "Kowalski" },
                    { 2, new DateTime(1996, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Anna", "Malewska" },
                    { 3, new DateTime(1994, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, "Piotr", "Zalewski" }
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
