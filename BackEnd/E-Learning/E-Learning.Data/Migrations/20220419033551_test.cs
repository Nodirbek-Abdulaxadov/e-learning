using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Learning.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropColumn(
                name: "ContentBody",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "VideoLink",
                table: "Courses",
                newName: "PageLink");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PageLink",
                table: "Courses",
                newName: "VideoLink");

            migrationBuilder.AddColumn<string>(
                name: "ContentBody",
                table: "Courses",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: true),
                    FileLink = table.Column<string>(type: "text", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FileSize = table.Column<string>(type: "text", nullable: true),
                    FileType = table.Column<string>(type: "text", nullable: true),
                    KursId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_CourseId",
                table: "Files",
                column: "CourseId");
        }
    }
}
