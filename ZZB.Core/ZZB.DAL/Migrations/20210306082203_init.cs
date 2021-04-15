using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZZB.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrtUser = table.Column<string>(nullable: true),
                    ModifyUser = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    UploaderId = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FileFullName = table.Column<string>(nullable: true),
                    HashCode = table.Column<string>(nullable: true),
                    Uri = table.Column<string>(nullable: true),
                    FileSize = table.Column<long>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrtUser = table.Column<string>(nullable: true),
                    ModifyUser = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    AccountID = table.Column<string>(nullable: true),
                    PassWork = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    IsAdministrator = table.Column<bool>(nullable: true),
                    Alias_name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    IsLogin = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeiXinConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrtUser = table.Column<string>(nullable: true),
                    ModifyUser = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    AppId = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Token_EndDate = table.Column<DateTime>(nullable: true),
                    AppSecret = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeiXinConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WX_Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrtUser = table.Column<string>(nullable: true),
                    ModifyUser = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    Btn_Type = table.Column<int>(nullable: false),
                    Content_Type = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Media_id = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    WX_MenuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WX_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WX_Menus_WX_Menus_WX_MenuId",
                        column: x => x.WX_MenuId,
                        principalTable: "WX_Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WX_Menus_WX_MenuId",
                table: "WX_Menus",
                column: "WX_MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileInfos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WeiXinConfigs");

            migrationBuilder.DropTable(
                name: "WX_Menus");
        }
    }
}
