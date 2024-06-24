using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppApi.Migrations
{
    public partial class CreatedCategoryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { 1, new DateTime(2024, 6, 12, 11, 55, 12, 826, DateTimeKind.Local).AddTicks(3867), "UI UX" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { 2, new DateTime(2024, 6, 12, 11, 55, 12, 826, DateTimeKind.Local).AddTicks(3875), "Backend" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { 3, new DateTime(2024, 6, 12, 11, 55, 12, 826, DateTimeKind.Local).AddTicks(3876), "Frontend" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
