namespace entityLianXi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTdName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductOrders", newName: "ProAndOrd");
            RenameColumn(table: "dbo.ProAndOrd", name: "Product_Pid", newName: "productId");
            RenameColumn(table: "dbo.ProAndOrd", name: "Order_Oid", newName: "orderId");
            RenameIndex(table: "dbo.ProAndOrd", name: "IX_Product_Pid", newName: "IX_productId");
            RenameIndex(table: "dbo.ProAndOrd", name: "IX_Order_Oid", newName: "IX_orderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProAndOrd", name: "IX_orderId", newName: "IX_Order_Oid");
            RenameIndex(table: "dbo.ProAndOrd", name: "IX_productId", newName: "IX_Product_Pid");
            RenameColumn(table: "dbo.ProAndOrd", name: "orderId", newName: "Order_Oid");
            RenameColumn(table: "dbo.ProAndOrd", name: "productId", newName: "Product_Pid");
            RenameTable(name: "dbo.ProAndOrd", newName: "ProductOrders");
        }
    }
}
