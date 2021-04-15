using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZZB.DAL.Migrations
{
    public partial class editdocument19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "DocumentInfos");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "DocumentInfos",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 9, 23, 14, 40, 686, DateTimeKind.Local).AddTicks(4208), new DateTime(2021, 3, 9, 23, 14, 40, 687, DateTimeKind.Local).AddTicks(934) });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentInfos_FileId",
                table: "DocumentInfos",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentInfos_FileInfos_FileId",
                table: "DocumentInfos",
                column: "FileId",
                principalTable: "FileInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentInfos_FileInfos_FileId",
                table: "DocumentInfos");

            migrationBuilder.DropIndex(
                name: "IX_DocumentInfos_FileId",
                table: "DocumentInfos");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "DocumentInfos");

            migrationBuilder.AddColumn<int>(
                name: "FileSize",
                table: "DocumentInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 9, 0, 37, 29, 18, DateTimeKind.Local).AddTicks(7864), new DateTime(2021, 3, 9, 0, 37, 29, 19, DateTimeKind.Local).AddTicks(4172) });
        }
    }
}
