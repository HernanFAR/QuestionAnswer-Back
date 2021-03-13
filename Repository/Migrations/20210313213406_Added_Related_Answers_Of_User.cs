using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Added_Related_Answers_Of_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuestionAnswerUserId",
                table: "Answers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ac0bfb48-782b-48f9-b425-20c56f60a59a", 0, "876acc24-639b-47d0-a3aa-b75e1fe94b54", "h.f.alvarez.r@gmail.com", false, true, true, null, "H.F.ALVAREZ.R@GMAIL.COM", "ENRYU19_", null, "+56 9 4979 8355", false, "9f8f72f9-7380-4e0a-817e-414f630b7367", false, "Enryu19_" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 18, 34, 6, 47, DateTimeKind.Local).AddTicks(987), new DateTime(2021, 3, 13, 18, 34, 6, 49, DateTimeKind.Local).AddTicks(5658) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 18, 34, 6, 49, DateTimeKind.Local).AddTicks(7328), new DateTime(2021, 3, 13, 18, 34, 6, 49, DateTimeKind.Local).AddTicks(7345) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 18, 34, 6, 49, DateTimeKind.Local).AddTicks(7350), new DateTime(2021, 3, 13, 18, 34, 6, 49, DateTimeKind.Local).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 18, 34, 6, 49, DateTimeKind.Local).AddTicks(7356), new DateTime(2021, 3, 13, 18, 34, 6, 49, DateTimeKind.Local).AddTicks(7359) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 18, 34, 6, 49, DateTimeKind.Local).AddTicks(7362), new DateTime(2021, 3, 13, 18, 34, 6, 49, DateTimeKind.Local).AddTicks(7364) });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionAnswerUserId",
                table: "Answers",
                column: "QuestionAnswerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_QuestionAnswerUserId",
                table: "Answers",
                column: "QuestionAnswerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_QuestionAnswerUserId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionAnswerUserId",
                table: "Answers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac0bfb48-782b-48f9-b425-20c56f60a59a");

            migrationBuilder.DropColumn(
                name: "QuestionAnswerUserId",
                table: "Answers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "", 0, "", "h.f.alvarez.r@gmail.com", false, true, true, null, "H.F.ALVAREZ.R@GMAIL.COM", "ENRYU19_", null, "+56 9 4979 8355", false, "", false, "Enryu19_" });

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
    }
}
