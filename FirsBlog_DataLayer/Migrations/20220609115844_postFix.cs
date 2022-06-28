using Microsoft.EntityFrameworkCore.Migrations;

namespace FirsBlog_DataLayer.Migrations
{
    public partial class postFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecCategoryId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SecCategoryId",
                table: "Posts",
                column: "SecCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_SecCategoryId",
                table: "Posts",
                column: "SecCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_SecCategoryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_SecCategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SecCategoryId",
                table: "Posts");
        }
    }
}
