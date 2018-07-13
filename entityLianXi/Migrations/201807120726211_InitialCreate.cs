namespace entityLianXi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Cid = c.Int(nullable: false, identity: true),
                        CName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Cid);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Pid = c.Int(nullable: false, identity: true),
                        PName = c.String(nullable: false),
                        Pice = c.Int(),
                        Detail = c.String(maxLength: 200),
                        Cid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pid)
                .ForeignKey("dbo.Categories", t => t.Cid, cascadeDelete: true)
                .Index(t => t.Cid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Cid", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Cid" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
