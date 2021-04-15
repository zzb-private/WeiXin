using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZZB.DAL.Migrations
{
    public partial class ssdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 18, 9, 51, 14, 534, DateTimeKind.Local).AddTicks(5160), new DateTime(2021, 3, 18, 9, 51, 14, 535, DateTimeKind.Local).AddTicks(1983) });

            migrationBuilder.UpdateData(
                table: "WeiXinConfigs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 18, 9, 51, 14, 536, DateTimeKind.Local).AddTicks(5678), new DateTime(2021, 3, 18, 9, 51, 14, 536, DateTimeKind.Local).AddTicks(5692) });

            migrationBuilder.InsertData(
                table: "WeiXinConfigs",
                columns: new[] { "Id", "AppId", "AppSecret", "CreateDate", "CrtUser", "ModifyDate", "ModifyUser", "Token", "Token_EndDate" },
                values: new object[] { 2, "wxadba2b2b6f7f500d", "6eac8313f13a959ce1521af5c3fd388e", new DateTime(2021, 3, 18, 9, 51, 14, 536, DateTimeKind.Local).AddTicks(6634), null, new DateTime(2021, 3, 18, 9, 51, 14, 536, DateTimeKind.Local).AddTicks(6639), null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeiXinConfigs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 18, 1, 20, 0, 808, DateTimeKind.Local).AddTicks(7014), new DateTime(2021, 3, 18, 1, 20, 0, 809, DateTimeKind.Local).AddTicks(3390) });

            migrationBuilder.UpdateData(
                table: "WeiXinConfigs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 18, 1, 20, 0, 810, DateTimeKind.Local).AddTicks(7335), new DateTime(2021, 3, 18, 1, 20, 0, 810, DateTimeKind.Local).AddTicks(7345) });
        }
    }
}
