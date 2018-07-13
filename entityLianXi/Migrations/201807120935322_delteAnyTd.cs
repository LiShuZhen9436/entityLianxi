namespace entityLianXi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delteAnyTd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProAndOrd", "productId", "dbo.Pro");
            DropForeignKey("dbo.ProAndOrd", "orderId", "dbo.Orders");
            DropIndex("dbo.ProAndOrd", new[] { "productId" });
            DropIndex("dbo.ProAndOrd", new[] { "orderId" });
            DropColumn("dbo.Pro", "Oid");
            DropTable("dbo.ProAndOrd");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProAndOrd",
                c => new
                    {
                        productId = c.Int(nullable: false),
                        orderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.productId, t.orderId });
            
            AddColumn("dbo.Pro", "Oid", c => c.Int(nullable: false));
            CreateIndex("dbo.ProAndOrd", "orderId");
            CreateIndex("dbo.ProAndOrd", "productId");
            AddForeignKey("dbo.ProAndOrd", "orderId", "dbo.Orders", "Oid", cascadeDelete: true);
            AddForeignKey("dbo.ProAndOrd", "productId", "dbo.Pro", "Pid", cascadeDelete: true);
        }
    }
}
