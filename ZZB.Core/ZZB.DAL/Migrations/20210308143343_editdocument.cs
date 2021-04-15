using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZZB.DAL.Migrations
{
    public partial class editdocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsShare",
                table: "DocumentInfos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 8, 22, 33, 43, 322, DateTimeKind.Local).AddTicks(5332), new DateTime(2021, 3, 8, 22, 33, 43, 323, DateTimeKind.Local).AddTicks(2090) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsShare",
                table: "DocumentInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 7, 23, 15, 6, 720, DateTimeKind.Local).AddTicks(7811), new DateTime(2021, 3, 7, 23, 15, 6, 721, DateTimeKind.Local).AddTicks(4642) });
        }
    }
}
