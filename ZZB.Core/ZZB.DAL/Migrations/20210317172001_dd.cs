using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZZB.DAL.Migrations
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 18, 1, 20, 0, 808, DateTimeKind.Local).AddTicks(7014), new DateTime(2021, 3, 18, 1, 20, 0, 809, DateTimeKind.Local).AddTicks(3390) });

            migrationBuilder.InsertData(
                table: "WeiXinConfigs",
                columns: new[] { "Id", "AppId", "AppSecret", "CreateDate", "CrtUser", "ModifyDate", "ModifyUser", "Token", "Token_EndDate" },
                values: new object[] { 1, "wxdcb4be3beeb08ba0", "bec0f3c8c33cebbabf5acec9f3815810", new DateTime(2021, 3, 18, 1, 20, 0, 810, DateTimeKind.Local).AddTicks(7335), null, new DateTime(2021, 3, 18, 1, 20, 0, 810, DateTimeKind.Local).AddTicks(7345), null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeiXinConfigs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 17, 9, 1, 21, 603, DateTimeKind.Local).AddTicks(9726), new DateTime(2021, 3, 17, 9, 1, 21, 604, DateTimeKind.Local).AddTicks(5899) });
        }
    }
}
