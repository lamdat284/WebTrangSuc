namespace Nhom04_Jewelry.Migrations
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
                        CategoryID = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.ChiTietDonHangs",
                c => new
                    {
                        MaDonHang = c.Long(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        SoLuong = c.Double(),
                        DongGia = c.Double(),
                        NgayThanhToan = c.DateTime(),
                        ProductID = c.Long(nullable: false),
                        MaKhachHang = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MaDonHang)
                .ForeignKey("dbo.KhachHangs", t => t.MaKhachHang, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKhachHang = c.Long(nullable: false, identity: true),
                        HoTen = c.String(nullable: false),
                        NgaySinh = c.DateTime(),
                        GioiTinh = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Long(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Double(),
                        Descriptions = c.String(),
                        Images = c.String(),
                        Imagess = c.String(),
                        CategoryID = c.Long(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietDonHangs", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.ChiTietDonHangs", "MaKhachHang", "dbo.KhachHangs");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.ChiTietDonHangs", new[] { "MaKhachHang" });
            DropIndex("dbo.ChiTietDonHangs", new[] { "ProductID" });
            DropTable("dbo.Products");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.ChiTietDonHangs");
            DropTable("dbo.Categories");
        }
    }
}
