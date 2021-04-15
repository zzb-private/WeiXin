using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZZB.DAL.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountID", "Alias_name", "CreateDate", "CrtUser", "IsAdministrator", "IsLogin", "ModifyDate", "ModifyUser", "PassWork", "Status", "UserName" },
                values: new object[] { 1, "zzb", null, new DateTime(2021, 3, 6, 16, 38, 12, 883, DateTimeKind.Local).AddTicks(1934), null, true, null, new DateTime(2021, 3, 6, 16, 38, 12, 884, DateTimeKind.Local).AddTicks(696), null, "123", 0, "拿破仑" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
