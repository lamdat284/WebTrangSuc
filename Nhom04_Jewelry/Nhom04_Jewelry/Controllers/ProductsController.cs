using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom04_Jewelry.Filters;
using Nhom04_Jewelry.Models;

namespace Nhom04_Jewelry.Controllers
{
    public class ProductsController : Controller
    {
        ProductDB db = new ProductDB();
        // GET: Products
        public ActionResult Index(string search="", string SortColumn = "", string IconClass = "", int page = 1)
        {
            List<Product> products = db.Products.Where(p => p.ProductName.Contains(search)).ToList();
            ViewBag.Search = search;
            ViewBag.IconClass = IconClass;
            ViewBag.SortColum = SortColumn;
            ViewBag.Name = "Sắp xếp";
            if (SortColumn == "PriceT")
            {
                if (IconClass == "asc")
                {
                    ViewBag.Name = "Giá tăng dần";
                    products = products.OrderBy(row => row.Price).ToList();
                }
              
            }else if (SortColumn == "PriceG")
            {
                if (IconClass == "desc")
                {
                    ViewBag.Name = "Giá giảm dần";
                    products = products.OrderByDescending(row => row.Price).ToList();
                }              
            }
            else if (SortColumn == "NameT")
            {
                if (IconClass == "asc")
                {
                    ViewBag.Name = "Tên tăng dần";
                    products = products.OrderBy(row => row.ProductName).ToList();
                }
            }else if (SortColumn == "NameG") {
                if (IconClass == "desc")
                {
                    ViewBag.Name = "Tên giảm dần";
                    products = products.OrderByDescending(row => row.ProductName).ToList();
                }
            }
            int NoOfRecordPerPage = 12;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(products);
        }
        public ActionResult Category(long id, int page = 1)
        {
            List<Product> products = db.Products.Where(row => row.CategoryID == id).ToList();

            int NoOfRecordPerPage = 12;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            ViewBag.ID = id;
            string banner = "";
            if (id == 1)
            {
                banner = "banner1.png";
            }
            else if (id == 2)
            {
                banner = "banner2.png";
            }
            else
            {
                banner = "banner3.png";
            }
            ViewBag.Banner = banner;
            return View(products);
        }
        [AuthenFilter]
        public ActionResult Detail(int id)
        {
            Product products = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            string banner = "";
            if (products.CategoryID == 1)
            {
                banner = "banner1.png";
            }
            else if (products.CategoryID == 2)
            {
                banner = "banner2.png";
            }
            else
            {
                banner = "banner3.png";
            }
            ViewBag.Banner = banner;
            return View(products);
        }

        [NonAction]
        public void LuuGioHang(GioHang gio)
        {
            Session["gh"] = gio;
        }
        [NonAction]
        public GioHang LayGioHang()
        {
            // biến nằm trong server, đưa về client
            GioHang gio = (GioHang)Session["gh"];
            return gio;
        }
        public ActionResult chonMua(int id)
        {
            GioHang g = LayGioHang();

            if (g == null)
            {
                g = new GioHang();
                g.Them(id);
            }
            else
            {
                // kiểm tra tour đó đã tồn tại trong đặt tour hay chưa
                Item s = g.lstSP.FirstOrDefault(t => t.ProductID == id);
                if (s == null)
                {
                    g.Them(id);
                }
                else // đã có, tăng số lượng lên 1
                {
                    s.soLuongMua++;
                }
            }
            LuuGioHang(g);
            return RedirectToAction("Index");
        }

        public ActionResult xemGioHang()
        {
            GioHang g = LayGioHang();
            if (g == null) {             
                return RedirectToAction("Carts","Cart");
            }
            else
            {
                List<Item> ds = g.lstSP;
                return View(ds);
            }

            
        }
        public ActionResult UpdateQuantity(FormCollection form)
        {
            var cart = LayGioHang();
            int id_product = Convert.ToInt16(form["ID_Product"]);
            int quantity_product = Convert.ToInt16(form["Quantity_Product"]);
            cart.Update_Quantity(id_product, quantity_product);
            return RedirectToAction("xemGioHang", "Products");
        }
        public ActionResult DeleteToProduct(int id)
        {
            var cart = LayGioHang();
            cart.DeleteProduct(id);
            return RedirectToAction("xemGioHang", "Products");
        }
    }
}