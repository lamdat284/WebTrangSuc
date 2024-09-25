using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom04_Jewelry.Models;

namespace Nhom04_Jewelry.Controllers
{
    public class HomeController : Controller
    {
        ProductDB db = new ProductDB();
        // GET: Home
        public ActionResult Index()
        {
            List<Product> products = db.Products.ToList();
            Random random = new Random();
            for (int i = products.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                Product temp = products[i];
                products[i] = products[j];
                products[j] = temp;
            }
            ViewBag.Product = db.Products.ToList();
            Random random1 = new Random();
            ViewBag.rand = random1.Next(1, 30);

            return View(products);
            
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}