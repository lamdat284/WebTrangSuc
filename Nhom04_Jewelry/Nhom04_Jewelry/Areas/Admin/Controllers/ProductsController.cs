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
    public class ProductsController : Controller
    {
        ProductDB db = new ProductDB();
        // GET: Admin/Products
       
        
        public ActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.Categories = db.Categories.ToList();
                return View();
            }

        }

      
        public ActionResult Update(int id)
        {
            var sanPhamModel = db.Products.Find(id);
            return View(sanPhamModel);
        }

        [HttpPost]
        public ActionResult Update(Product sp)
        {
            if (string.IsNullOrEmpty(sp.ProductName) == true)
            {
                ModelState.AddModelError("", "Tên sản phẩm không được để trống");
                return View(sp);
            }

            var update = db.Products.Find(sp.ProductID);
            update.ProductName = sp.ProductName;
            update.Price = sp.Price;
            update.Descriptions = sp.Descriptions;
            update.Images = sp.Images;
            update.Imagess = sp.Imagess;
            update.CategoryID = sp.CategoryID;

            var id = db.SaveChanges();
            if (id > 0)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("", "Không lưu được");
                return View(sp);
            }
        }
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(int id, Product p)
        {
            Product product = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("index","Home");
        }

        public ActionResult Loai(long id, int page = 1)
        {
            List<Product> products = db.Products.Where(row => row.CategoryID == id).ToList();

            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            ViewBag.ID = id;
            return View(products);
        }
    }
}