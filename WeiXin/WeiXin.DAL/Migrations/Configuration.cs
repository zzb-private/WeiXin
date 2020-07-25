namespace WeiXin.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WeiXinDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WeiXinDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.WeiXinConfigs.AddOrUpdate(
                  new WeiXin.WeiXinConfig() {
                      AppId = "wxdcb4be3beeb08ba0",
                      AppSecret = "bec0f3c8c33cebbabf5acec9f3815810",
                      Id = 1,
                      CreateDate = DateTime.Now,
                      Token = ""
                  },
                  new WeiXin.WeiXinConfig() {
                  }
                );
        }
    }
}
