using Microsoft.EntityFrameworkCore;
using System;
using ZZB.DAL.Admin;
using ZZB.DAL.File;
using ZZB.DAL.WeiXin;

namespace ZZB.DAL
{
    /// <summary>
    /// 数据库上下文操作类
    /// </summary>
    public class ZZBDbContext : DbContext
    {
        public ZZBDbContext(DbContextOptions<ZZBDbContext> options)
            : base(options)
        {

        }

        public DbSet<WeiXinConfig> WeiXinConfigs { get; set; }
        public DbSet<WX_Menu> WX_Menus { get; set; }
        //public DbSet<WX_ForeverFile> WX_ForeverFiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SystemFileInfo> FileInfos { get; set; }
        public DbSet<DocumentInfo> DocumentInfos { get; set; }
        public DbSet<WX_UserInfo> WX_UserInfos { get; set; }//粉丝表
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<DealerMarketDptRelation>()
            //  .HasOne(d => d.MarketingDepartment)
            //  .WithMany(e => e.DealerMarketDptRelations)
            //  .HasForeignKey(d => d.MarketId);

            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                AccountID = "zzb",
                Status = UserStatus.正常,
                PassWork = "123",
                UserName = "拿破仑",
                IsAdministrator = true
            });

            modelBuilder.Entity<WeiXinConfig>().HasData(new WeiXinConfig()
            {
                Id = 1,
                AppId = "wxdcb4be3beeb08ba0",
                AppSecret = "bec0f3c8c33cebbabf5acec9f3815810",
            });
            modelBuilder.Entity<WeiXinConfig>().HasData(new WeiXinConfig()
            {
                Id = 2,
                AppId = "wxadba2b2b6f7f500d",
                AppSecret = "6eac8313f13a959ce1521af5c3fd388e",
            });
        }
    }
}
