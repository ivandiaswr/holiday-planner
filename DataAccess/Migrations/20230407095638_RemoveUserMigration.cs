using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Plans");

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 7, 10, 56, 37, 971, DateTimeKind.Local).AddTicks(2792), new DateTime(2023, 4, 7, 10, 56, 37, 971, DateTimeKind.Local).AddTicks(2759) });

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 7, 10, 56, 37, 971, DateTimeKind.Local).AddTicks(2799), new DateTime(2023, 4, 7, 10, 56, 37, 971, DateTimeKind.Local).AddTicks(2797) });

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 7, 10, 56, 37, 971, DateTimeKind.Local).AddTicks(2804), new DateTime(2023, 4, 7, 10, 56, 37, 971, DateTimeKind.Local).AddTicks(2802) });

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 7, 10, 56, 37, 971, DateTimeKind.Local).AddTicks(2808), new DateTime(2023, 4, 7, 10, 56, 37, 971, DateTimeKind.Local).AddTicks(2807) });

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 7, 10, 56, 37, 971, DateTimeKind.Local).AddTicks(2813), new DateTime(2023, 4, 7, 10, 56, 37, 971, DateTimeKind.Local).AddTicks(2811) });

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 7, 10, 56, 37, 971, DateTimeKind.Local).AddTicks(2819), new DateTime(2023, 4, 7, 10, 56, 37, 971, DateTimeKind.Local).AddTicks(2817) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7737), new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7701), 1 });

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7744), new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7743), 2 });

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7749), new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7748), 3 });

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7754), new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7753), 4 });

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7761), new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7759), 5 });

            migrationBuilder.UpdateData(
                table: "Plans",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7767), new DateTime(2023, 3, 29, 9, 52, 38, 428, DateTimeKind.Local).AddTicks(7765), 6 });

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
    }
}
