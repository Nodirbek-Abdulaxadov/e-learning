using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Learning.Data.Migrations
{
    public partial class editfilemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Courses_CourseId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Files",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "file_type",
                table: "Files",
                newName: "FileType");

            migrationBuilder.RenameColumn(
                name: "file_size",
                table: "Files",
                newName: "FileSize");

            migrationBuilder.RenameColumn(
                name: "file_name",
                table: "Files",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "file",
                table: "Files",
                newName: "FileLink");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Files",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Courses_CourseId",
                table: "Files",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Courses_CourseId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Files",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "Files",
                newName: "file_type");

            migrationBuilder.RenameColumn(
                name: "FileSize",
                table: "Files",
                newName: "file_size");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Files",
                newName: "file_name");

            migrationBuilder.RenameColumn(
                name: "FileLink",
                table: "Files",
                newName: "file");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Files",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Courses_CourseId",
                table: "Files",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
