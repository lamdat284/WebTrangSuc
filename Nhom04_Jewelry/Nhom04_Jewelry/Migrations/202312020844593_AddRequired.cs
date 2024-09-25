namespace Nhom04_Jewelry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            AlterColumn("dbo.ChiTietDonHangs", "SoLuong", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "CategoryID", c => c.Long(nullable: false));
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            AlterColumn("dbo.Products", "CategoryID", c => c.Long());
            AlterColumn("dbo.Products", "Price", c => c.Double());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.ChiTietDonHangs", "SoLuong", c => c.Double());
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "CategoryID");
        }
    }
}
