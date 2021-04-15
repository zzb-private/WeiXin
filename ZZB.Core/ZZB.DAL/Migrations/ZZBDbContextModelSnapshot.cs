﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZZB.DAL;

namespace ZZB.DAL.Migrations
{
    [DbContext(typeof(ZZBDbContext))]
    partial class ZZBDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZZB.DAL.Admin.SystemFileInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CrtUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("HashCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifyUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UploaderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uri")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FileInfos");
                });

            modelBuilder.Entity("ZZB.DAL.Admin.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Alias_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CrtUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsAdministrator")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsLogin")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifyUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWork")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountID = "zzb",
                            CreateDate = new DateTime(2021, 3, 18, 9, 51, 14, 534, DateTimeKind.Local).AddTicks(5160),
                            IsAdministrator = true,
                            ModifyDate = new DateTime(2021, 3, 18, 9, 51, 14, 535, DateTimeKind.Local).AddTicks(1983),
                            PassWork = "123",
                            Status = 0,
                            UserName = "拿破仑"
                        });
                });

            modelBuilder.Entity("ZZB.DAL.File.DocumentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CrtUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocumentInfoId")
                        .HasColumnType("int");

                    b.Property<int?>("FileId")
                        .HasColumnType("int");

                    b.Property<string>("ICon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFolder")
                        .HasColumnType("bit");

                    b.Property<bool>("IsShare")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifyUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocumentInfoId");

                    b.HasIndex("FileId");

                    b.ToTable("DocumentInfos");
                });

            modelBuilder.Entity("ZZB.DAL.WeiXin.WX_Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Btn_Type")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Content_Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CrtUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Media_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifyUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WX_MenuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WX_MenuId");

                    b.ToTable("WX_Menus");
                });

            modelBuilder.Entity("ZZB.DAL.WeiXin.WX_UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CrtUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifyUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("groupid")
                        .HasColumnType("int");

                    b.Property<string>("headimgurl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("openid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("qr_scene")
                        .HasColumnType("int");

                    b.Property<string>("qr_scene_str")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sex")
                        .HasColumnType("int");

                    b.Property<int>("subscribe")
                        .HasColumnType("int");

                    b.Property<string>("subscribe_scene")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subscribe_time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unionid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WX_UserInfos");
                });

            modelBuilder.Entity("ZZB.DAL.WeiXin.WeiXinConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppSecret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CrtUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifyUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Token_EndDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WeiXinConfigs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppId = "wxdcb4be3beeb08ba0",
                            AppSecret = "bec0f3c8c33cebbabf5acec9f3815810",
                            CreateDate = new DateTime(2021, 3, 18, 9, 51, 14, 536, DateTimeKind.Local).AddTicks(5678),
                            ModifyDate = new DateTime(2021, 3, 18, 9, 51, 14, 536, DateTimeKind.Local).AddTicks(5692)
                        },
                        new
                        {
                            Id = 2,
                            AppId = "wxadba2b2b6f7f500d",
                            AppSecret = "6eac8313f13a959ce1521af5c3fd388e",
                            CreateDate = new DateTime(2021, 3, 18, 9, 51, 14, 536, DateTimeKind.Local).AddTicks(6634),
                            ModifyDate = new DateTime(2021, 3, 18, 9, 51, 14, 536, DateTimeKind.Local).AddTicks(6639)
                        });
                });

            modelBuilder.Entity("ZZB.DAL.File.DocumentInfo", b =>
                {
                    b.HasOne("ZZB.DAL.File.DocumentInfo", null)
                        .WithMany("DocumentInfos")
                        .HasForeignKey("DocumentInfoId");

                    b.HasOne("ZZB.DAL.Admin.SystemFileInfo", "SystemFileInfo")
                        .WithMany()
                        .HasForeignKey("FileId");

                    b.Navigation("SystemFileInfo");
                });

            modelBuilder.Entity("ZZB.DAL.WeiXin.WX_Menu", b =>
                {
                    b.HasOne("ZZB.DAL.WeiXin.WX_Menu", null)
                        .WithMany("SubMenu")
                        .HasForeignKey("WX_MenuId");
                });

            modelBuilder.Entity("ZZB.DAL.File.DocumentInfo", b =>
                {
                    b.Navigation("DocumentInfos");
                });

            modelBuilder.Entity("ZZB.DAL.WeiXin.WX_Menu", b =>
                {
                    b.Navigation("SubMenu");
                });
#pragma warning restore 612, 618
        }
    }
}
