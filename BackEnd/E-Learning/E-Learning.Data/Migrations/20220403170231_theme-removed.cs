using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Learning.Data.Migrations
{
    public partial class themeremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Themes_ThemeId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ThemeId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "ThemeId",
                table: "Courses",
                newName: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Courses",
                newName: "ThemeId");

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SectionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ThemeId",
                table: "Courses",
                column: "ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Themes_ThemeId",
                table: "Courses",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
