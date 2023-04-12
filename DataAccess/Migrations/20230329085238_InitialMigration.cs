using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddicionalInformation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "Id", "AddicionalInformation", "EndDate", "Name", "Place", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7737), "Name1", "Place1", new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7701), 1 },
                    { 2, "", new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7744), "Name2", "Place2", new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7743), 2 },
                    { 3, "", new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7749), "Name3", "Place3", new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7748), 3 },
                    { 4, "", new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7754), "Name4", "Place4", new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7753), 4 },
                    { 5, "", new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7761), "Name5", "Place5", new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7759), 5 },
                    { 6, "", new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7767), "Name6", "Place6", new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7765), 6 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "Password1", "Name1" },
                    { 2, "Password2", "Name2" },
                    { 3, "Password3", "Name3" },
                    { 4, "Password4", "Name4" },
                    { 5, "Password5", "Name5" },
                    { 6, "Password6", "Name6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
