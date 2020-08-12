using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiXin.DAL.WeiXin;

namespace WeiXin.DAL
{
    /// <summary>
    /// 数据库上下文操作类
    /// </summary>
    public class WeiXinDbContext:DbContext 
    {
        public  WeiXinDbContext():base("DefaultConnection")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WeiXinDbContext>());
            //Database.SetInitializer<WeiXinDbContext>(null);
        }

        public DbSet<WeiXinConfig> WeiXinConfigs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new ProvinceMap());
            //modelBuilder.Configurations.Add(new CategoryMap());
        }
    
    }
}
