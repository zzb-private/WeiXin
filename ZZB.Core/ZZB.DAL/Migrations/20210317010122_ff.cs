using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZZB.DAL.Migrations
{
    public partial class ff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentInfos_Users_UserId",
                table: "DocumentInfos");

            migrationBuilder.DropIndex(
                name: "IX_DocumentInfos_UserId",
                table: "DocumentInfos");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 17, 9, 1, 21, 603, DateTimeKind.Local).AddTicks(9726), new DateTime(2021, 3, 17, 9, 1, 21, 604, DateTimeKind.Local).AddTicks(5899) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 16, 9, 7, 12, 872, DateTimeKind.Local).AddTicks(4391), new DateTime(2021, 3, 16, 9, 7, 12, 873, DateTimeKind.Local).AddTicks(1091) });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentInfos_UserId",
                table: "DocumentInfos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentInfos_Users_UserId",
                table: "DocumentInfos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
