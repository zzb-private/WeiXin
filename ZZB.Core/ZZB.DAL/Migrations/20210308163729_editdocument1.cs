using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZZB.DAL.Migrations
{
    public partial class editdocument1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 9, 0, 37, 29, 18, DateTimeKind.Local).AddTicks(7864), new DateTime(2021, 3, 9, 0, 37, 29, 19, DateTimeKind.Local).AddTicks(4172) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 8, 22, 33, 43, 322, DateTimeKind.Local).AddTicks(5332), new DateTime(2021, 3, 8, 22, 33, 43, 323, DateTimeKind.Local).AddTicks(2090) });
        }
    }
}
