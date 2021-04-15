using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZZB.DAL.Migrations
{
    public partial class ss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrtUser = table.Column<string>(nullable: true),
                    ModifyUser = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    IsFolder = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ICon = table.Column<string>(nullable: true),
                    IsShare = table.Column<string>(nullable: true),
                    FileSize = table.Column<int>(nullable: false),
                    DocumentInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentInfos_DocumentInfos_DocumentInfoId",
                        column: x => x.DocumentInfoId,
                        principalTable: "DocumentInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 7, 23, 15, 6, 720, DateTimeKind.Local).AddTicks(7811), new DateTime(2021, 3, 7, 23, 15, 6, 721, DateTimeKind.Local).AddTicks(4642) });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentInfos_DocumentInfoId",
                table: "DocumentInfos",
                column: "DocumentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentInfos_UserId",
                table: "DocumentInfos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentInfos");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate" },
                values: new object[] { new DateTime(2021, 3, 6, 16, 38, 12, 883, DateTimeKind.Local).AddTicks(1934), new DateTime(2021, 3, 6, 16, 38, 12, 884, DateTimeKind.Local).AddTicks(696) });
        }
    }
}
