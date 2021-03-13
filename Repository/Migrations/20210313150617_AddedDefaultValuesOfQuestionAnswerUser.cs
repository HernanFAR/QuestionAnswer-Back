using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AddedDefaultValuesOfQuestionAnswerUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "", 0, "", "h.f.alvarez.r@gmail.com", false, true, true, null, "HERNAN.ALVAREZ@AUSTRANET.COM", "ENRYU19_", null, "+56 9 4979 8355", false, "", false, "Enryu19_" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 0, 50, 14, 724, DateTimeKind.Local).AddTicks(3969), new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7961), new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7974) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7978), new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7981) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7983), new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7986) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7988), new DateTime(2021, 3, 13, 0, 50, 14, 726, DateTimeKind.Local).AddTicks(7991) });
        }
    }
}
