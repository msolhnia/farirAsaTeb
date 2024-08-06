using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modelschanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Articles_ArticleId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_ArticleId",
                table: "Quizzes");

            migrationBuilder.AddColumn<int>(
                name: "ArticleModelId",
                table: "Quizzes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_ArticleModelId",
                table: "Quizzes",
                column: "ArticleModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Articles_ArticleModelId",
                table: "Quizzes",
                column: "ArticleModelId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Articles_ArticleModelId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_ArticleModelId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "ArticleModelId",
                table: "Quizzes");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_ArticleId",
                table: "Quizzes",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Articles_ArticleId",
                table: "Quizzes",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
