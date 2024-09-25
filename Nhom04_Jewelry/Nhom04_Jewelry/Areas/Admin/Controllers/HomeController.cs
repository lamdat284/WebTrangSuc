using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom04_Jewelry.Models;
using Nhom04_Jewelry.Filters;
namespace Nhom04_Jewelry.Areas.Admin.Controllers
{
    [AuthorFilter]
    public class HomeController : Controller
    {
        ProductDB db = new ProductDB();
        // GET: Admin/Home
        public ActionResult Index(int page=1)
        {
            List<Product> products = db.Products.ToList();

            int NoOfRecordPerPage = 4;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(products);
        }
    }
}