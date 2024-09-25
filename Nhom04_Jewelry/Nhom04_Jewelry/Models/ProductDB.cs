using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Nhom04_Jewelry.Models
{
    public class ProductDB:DbContext
    {
        public ProductDB() : base("Connection") { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}