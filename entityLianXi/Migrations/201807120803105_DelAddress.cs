namespace entityLianXi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelAddress : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Cid", newName: "CatId");
            RenameIndex(table: "dbo.Products", name: "IX_Cid", newName: "IX_CatId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_CatId", newName: "IX_Cid");
            RenameColumn(table: "dbo.Products", name: "CatId", newName: "Cid");
        }
    }
}
