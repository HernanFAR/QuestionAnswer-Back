using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Added_Votes_For_Answers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Votes",
                table: "Answers",
                newName: "UpVotes");

            migrationBuilder.AddColumn<int>(
                name: "DownVotes",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalVotes",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 14, 18, 19, 11, 452, DateTimeKind.Local).AddTicks(1809), new DateTime(2021, 3, 14, 18, 19, 11, 454, DateTimeKind.Local).AddTicks(4843) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 14, 18, 19, 11, 454, DateTimeKind.Local).AddTicks(6534), new DateTime(2021, 3, 14, 18, 19, 11, 454, DateTimeKind.Local).AddTicks(6548) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 14, 18, 19, 11, 454, DateTimeKind.Local).AddTicks(6552), new DateTime(2021, 3, 14, 18, 19, 11, 454, DateTimeKind.Local).AddTicks(6554) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 14, 18, 19, 11, 454, DateTimeKind.Local).AddTicks(6557), new DateTime(2021, 3, 14, 18, 19, 11, 454, DateTimeKind.Local).AddTicks(6559) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 14, 18, 19, 11, 454, DateTimeKind.Local).AddTicks(6562), new DateTime(2021, 3, 14, 18, 19, 11, 454, DateTimeKind.Local).AddTicks(6565) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DownVotes",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "TotalVotes",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "UpVotes",
                table: "Answers",
                newName: "Votes");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 19, 24, 57, 277, DateTimeKind.Local).AddTicks(1363), new DateTime(2021, 3, 13, 19, 24, 57, 280, DateTimeKind.Local).AddTicks(5164) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 19, 24, 57, 280, DateTimeKind.Local).AddTicks(7859), new DateTime(2021, 3, 13, 19, 24, 57, 280, DateTimeKind.Local).AddTicks(7886) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 19, 24, 57, 280, DateTimeKind.Local).AddTicks(7893), new DateTime(2021, 3, 13, 19, 24, 57, 280, DateTimeKind.Local).AddTicks(7896) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 19, 24, 57, 280, DateTimeKind.Local).AddTicks(7901), new DateTime(2021, 3, 13, 19, 24, 57, 280, DateTimeKind.Local).AddTicks(7905) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 19, 24, 57, 280, DateTimeKind.Local).AddTicks(7909), new DateTime(2021, 3, 13, 19, 24, 57, 280, DateTimeKind.Local).AddTicks(7912) });
        }
    }
}
