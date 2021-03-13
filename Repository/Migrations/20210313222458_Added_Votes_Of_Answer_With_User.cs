using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Added_Votes_Of_Answer_With_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionVotes_AspNetUsers_QuestionAnswerUserId",
                table: "QuestionVotes");

            migrationBuilder.CreateTable(
                name: "AnswerVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsUpVote = table.Column<bool>(type: "bit", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    QuestionAnswerUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerVotes_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnswerVotes_AspNetUsers_QuestionAnswerUserId",
                        column: x => x.QuestionAnswerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AnswerVotes_AnswerId",
                table: "AnswerVotes",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerVotes_QuestionAnswerUserId",
                table: "AnswerVotes",
                column: "QuestionAnswerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionVotes_AspNetUsers_QuestionAnswerUserId",
                table: "QuestionVotes",
                column: "QuestionAnswerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionVotes_AspNetUsers_QuestionAnswerUserId",
                table: "QuestionVotes");

            migrationBuilder.DropTable(
                name: "AnswerVotes");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 19, 16, 6, 142, DateTimeKind.Local).AddTicks(8829), new DateTime(2021, 3, 13, 19, 16, 6, 145, DateTimeKind.Local).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 19, 16, 6, 145, DateTimeKind.Local).AddTicks(4778), new DateTime(2021, 3, 13, 19, 16, 6, 145, DateTimeKind.Local).AddTicks(4799) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 19, 16, 6, 145, DateTimeKind.Local).AddTicks(4802), new DateTime(2021, 3, 13, 19, 16, 6, 145, DateTimeKind.Local).AddTicks(4804) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 19, 16, 6, 145, DateTimeKind.Local).AddTicks(4807), new DateTime(2021, 3, 13, 19, 16, 6, 145, DateTimeKind.Local).AddTicks(4809) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdated" },
                values: new object[] { new DateTime(2021, 3, 13, 19, 16, 6, 145, DateTimeKind.Local).AddTicks(4812), new DateTime(2021, 3, 13, 19, 16, 6, 145, DateTimeKind.Local).AddTicks(4814) });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionVotes_AspNetUsers_QuestionAnswerUserId",
                table: "QuestionVotes",
                column: "QuestionAnswerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
