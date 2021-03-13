using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class InitialCatalog_CategoryData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "LastUpdated", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 13, 0, 50, 14, 724, DateTimeKind.Local).AddTicks(3969), new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(6440), "Vida" },
                    { 2, new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7961), new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7974), "Juegos" },
                    { 3, new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7978), new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7981), "Amor" },
                    { 4, new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7983), new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7986), "Dolores" },
                    { 5, new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7988), new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7991), "Miselaneo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
