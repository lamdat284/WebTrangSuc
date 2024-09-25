using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom04_Jewelry.Models;
using Nhom04_Jewelry.Filters;

namespace Nhom04_Jewelry.Controllers
{
    
    public class CartController : Controller
    {
        ProductDB db = new ProductDB();
        // GET: Cart
        public ActionResult Carts()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Carts(Product sp)
        {
            List<Product> sanphams = new List<Product>();
            Product sanpham = db.Products.Where(row => row.ProductID == sp.ProductID).FirstOrDefault();
            sanphams.Add(sanpham);
            Session["cart"] = sanpham;
            return View(sanphams);
        }

    }
}