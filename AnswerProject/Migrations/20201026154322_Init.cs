using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnswerProject.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADate = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    DataType = table.Column<string>(nullable: true),
                    Enumeration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnswerItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question_Id = table.Column<long>(nullable: false),
                    Answer_Id = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerItems_Answers_Answer_Id",
                        column: x => x.Answer_Id,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerItems_Questions_Question_Id",
                        column: x => x.Question_Id,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DataType", "Enumeration", "Text" },
                values: new object[,]
                {
                    { 1L, "text", null, "Введите имя" },
                    { 2L, "number", null, "Введите возраст" },
                    { 3L, "enum", "муж;жен;неопр", "Введите пол" },
                    { 4L, "date", null, "Введите дату рождения" },
                    { 5L, "enum", "холост/не замужем;женат/замужем;разведен/а", "Введите семейное положение" },
                    { 6L, "checkbox", null, "Любите ли вы программировать" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerItems_Answer_Id",
                table: "AnswerItems",
                column: "Answer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerItems_Question_Id",
                table: "AnswerItems",
                column: "Question_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerItems");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
