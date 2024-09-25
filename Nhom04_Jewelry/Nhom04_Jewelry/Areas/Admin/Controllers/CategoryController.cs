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
    public class CategoryController : Controller
    {
        ProductDB db = new ProductDB();
        // GET: Admin/Category
        public ActionResult Index()
        {
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
        
    }
}