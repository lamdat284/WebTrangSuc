using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom04_Jewelry.Identity;
using Nhom04_Jewelry.Filters;

namespace Nhom04_Jewelry.Areas.Admin.Controllers
{
    [AuthorFilter]
    public class UserController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: User
        public ActionResult Index()
        {
            List<AppUser> appUsers = db.Users.ToList();
            return View(appUsers);
        }
    }
}