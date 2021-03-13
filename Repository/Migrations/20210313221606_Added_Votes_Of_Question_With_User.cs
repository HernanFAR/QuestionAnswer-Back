using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Added_Votes_Of_Question_With_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Votes",
                table: "Questions",
                newName: "UpVotes");

            migrationBuilder.AddColumn<int>(
                name: "DownVotes",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalVotes",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QuestionVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsUpVote = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    QuestionAnswerUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionVotes_AspNetUsers_QuestionAnswerUserId",
                        column: x => x.QuestionAnswerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionVotes_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_QuestionVotes_QuestionAnswerUserId",
                table: "QuestionVotes",
                column: "QuestionAnswerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionVotes_QuestionId",
                table: "QuestionVotes",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionVotes");

            migrationBuilder.DropColumn(
                name: "DownVotes",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "TotalVotes",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "UpVotes",
                table: "Questions",
                newName: "Votes");

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
        }
    }
}
