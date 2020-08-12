namespace WeiXin.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeiXinConfigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppId = c.String(),
                        Token = c.String(),
                        Token_EndDate = c.DateTime(),
                        AppSecret = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WeiXinConfigs");
        }
    }
}
