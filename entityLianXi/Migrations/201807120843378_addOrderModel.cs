namespace entityLianXi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrderModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Oid = c.Int(nullable: false, identity: true),
                        OName = c.String(),
                    })
                .PrimaryKey(t => t.Oid);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Product_Pid = c.Int(nullable: false),
                        Order_Oid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Pid, t.Order_Oid })
                .ForeignKey("dbo.Products", t => t.Product_Pid, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Oid, cascadeDelete: true)
                .Index(t => t.Product_Pid)
                .Index(t => t.Order_Oid);
            
            AddColumn("dbo.Products", "Oid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrders", "Order_Oid", "dbo.Orders");
            DropForeignKey("dbo.ProductOrders", "Product_Pid", "dbo.Products");
            DropIndex("dbo.ProductOrders", new[] { "Order_Oid" });
            DropIndex("dbo.ProductOrders", new[] { "Product_Pid" });
            DropColumn("dbo.Products", "Oid");
            DropTable("dbo.ProductOrders");
            DropTable("dbo.Orders");
        }
    }
}
