using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class EditedDefaultValuesOfQuestionAnswerUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "",
                column: "NormalizedEmail",
                value: "H.F.ALVAREZ.R@GMAIL.COM");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 17, 48, 4, 687, DateTimeKind.Local).AddTicks(1623), new DateTime(2021, 3, 13, 17, 48, 4, 689, DateTimeKind.Local).AddTicks(5982) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 17, 48, 4, 689, DateTimeKind.Local).AddTicks(7535), new DateTime(2021, 3, 13, 17, 48, 4, 689, DateTimeKind.Local).AddTicks(7551) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 17, 48, 4, 689, DateTimeKind.Local).AddTicks(7555), new DateTime(2021, 3, 13, 17, 48, 4, 689, DateTimeKind.Local).AddTicks(7557) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 17, 48, 4, 689, DateTimeKind.Local).AddTicks(7560), new DateTime(2021, 3, 13, 17, 48, 4, 689, DateTimeKind.Local).AddTicks(7563) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 17, 48, 4, 689, DateTimeKind.Local).AddTicks(7565), new DateTime(2021, 3, 13, 17, 48, 4, 689, DateTimeKind.Local).AddTicks(7567) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "",
                column: "NormalizedEmail",
                value: "HERNAN.ALVAREZ@AUSTRANET.COM");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 12, 6, 16, 652, DateTimeKind.Local).AddTicks(2153), new DateTime(2021, 3, 13, 12, 6, 16, 655, DateTimeKind.Local).AddTicks(4204) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 12, 6, 16, 655, DateTimeKind.Local).AddTicks(6433), new DateTime(2021, 3, 13, 12, 6, 16, 655, DateTimeKind.Local).AddTicks(6452) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 12, 6, 16, 655, DateTimeKind.Local).AddTicks(6459), new DateTime(2021, 3, 13, 12, 6, 16, 655, DateTimeKind.Local).AddTicks(6463) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 12, 6, 16, 655, DateTimeKind.Local).AddTicks(6467), new DateTime(2021, 3, 13, 12, 6, 16, 655, DateTimeKind.Local).AddTicks(6471) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 12, 6, 16, 655, DateTimeKind.Local).AddTicks(6475), new DateTime(2021, 3, 13, 12, 6, 16, 655, DateTimeKind.Local).AddTicks(6480) });
        }
    }
}
