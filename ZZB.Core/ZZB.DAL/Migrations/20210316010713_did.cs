using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZZB.DAL.Migrations
{
    public partial class did : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WX_UserInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subscribe = table.Column<int>(type: "int", nullable: false),
                    openid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sex = table.Column<int>(type: "int", nullable: false),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    headimgurl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subscribe_time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unionid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    groupid = table.Column<int>(type: "int", nullable: false),
                    subscribe_scene = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qr_scene = table.Column<int>(type: "int", nullable: false),
                    qr_scene_str = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrtUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WX_UserInfos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 16, 9, 7, 12, 872, DateTimeKind.Local).AddTicks(4391), new DateTime(2021, 3, 16, 9, 7, 12, 873, DateTimeKind.Local).AddTicks(1091) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WX_UserInfos");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 9, 23, 14, 40, 686, DateTimeKind.Local).AddTicks(4208), new DateTime(2021, 3, 9, 23, 14, 40, 687, DateTimeKind.Local).AddTicks(934) });
        }
    }
}
